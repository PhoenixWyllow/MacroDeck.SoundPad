using PW.MacroDeck.SoundPad.Models;
using PW.MacroDeck.SoundPad.Services;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.MacroDeck.SoundPad.ViewModels
{
    internal class PlayActionConfigViewModel : ISerializableConfigViewModel
    {
        private readonly PluginAction _action;

        ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

        public PlayActionConfigModel Configuration { get; set; }

        public SoundpadSound Sound
        {
            get => Configuration.Sound;
            set => Configuration.Sound = value;
        }

        public SoundpadCategory Category
        {
            get => Configuration.Category;
            set => Configuration.Category = value;
        }

        public List<SoundpadCategory> Categories { get; set; }

        public List<SoundpadSound> Sounds { get; set; }

        public PlayActionConfigViewModel(PluginAction action)
        {
            Configuration = PlayActionConfigModel.Deserialize(action.Configuration);
            _action = action;
        }

        public void SaveConfig()
        {
            try
            {
                SetConfig();
                MacroDeckLogger.Info(PluginInstance.Plugin, $"{GetType().Name}: config saved");
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Plugin, $"{GetType().Name}: config NOT saved");
                MacroDeckLogger.Error(PluginInstance.Plugin, $"{GetType().Name}: {ex.Message}");
            }
        }

        public void SetConfig()
        {
            _action.ConfigurationSummary = Configuration.ToString();
            _action.Configuration = Configuration.Serialize();
        }

        public void ChangeSound(string audioTitle = default)
        {
            if (!string.IsNullOrEmpty(audioTitle))
            {
                Sound = Sounds.FirstOrDefault(s => s.Title.Equals(audioTitle));
            }

            if (Sound != null && !Sounds.Any(s => s.Equals(Sound)))
            {
                Sound = Sounds.FirstOrDefault(s => s.Title.Equals(Sound.Title)) ?? Sounds.FirstOrDefault(s => s.Index.Equals(Sound.Index));
            }

            if (Sound == null && Configuration.AudioIndex > 0)
            {
                Sound = Sounds.FirstOrDefault(s => s.Index.Equals(Configuration.AudioIndex));
            }

            Configuration.AudioIndex = Sound.Index;
        }

        public void ChangeCategory(string categoryName = default)
        {
            if (!string.IsNullOrEmpty(categoryName))
            {
                Category = Categories.FirstOrDefault(c => c.Name.Equals(categoryName));
            }

            if (Category != null && !Categories.Any(c => c.Equals(Category)))
            {
                Category = Categories.FirstOrDefault(c => c.Name.Equals(Category.Name)) ?? Categories.FirstOrDefault(c => c.Index.Equals(Category.Index));
            }
            //separate condition in case changed to null (ie. category changed in Name and Index)
            if (Category == null)
            {
                Category = Categories.FirstOrDefault(c => c.Type == 1);
            }
        }

        public async Task FetchCategoriesAsync()
        {
            var categories = await SoundPadManager.Soundpad.GetCategories();
            Categories = categories.Value.Categories.Select(c => new SoundpadCategory(c)).ToList();
        }

        public async Task FetchSoundListAsync(string categoryName = default)
        {
            var soundList = await FetchSoundsAsync(categoryName);
            if (soundList != null)
            {
                Sounds = soundList.Select(s => new SoundpadSound(s)).ToList();
            }
        }

        private async Task<List<SoundpadConnector.XML.Sound>> FetchSoundsAsync(string categoryName = default)
        {
            if (string.IsNullOrEmpty(categoryName) || Categories.First(c => c.Name.Equals(categoryName)).Type == 1)
            {
                var soundlist = await SoundPadManager.Soundpad.GetSoundlist();
                return soundlist.Value.Sounds;
            }
            var category = await SoundPadManager.Soundpad.GetCategory(Categories.First(c => c.Name.Equals(categoryName)).Index, withSounds: true);
            return category.Value.Sounds;
        }
    }
}
