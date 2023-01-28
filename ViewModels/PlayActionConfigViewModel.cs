using PW.MacroDeck.SoundPad.Models;
using PW.MacroDeck.SoundPad.Services;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PW.MacroDeck.SoundPad.ViewModels
{
    internal class PlayActionConfigViewModel : ISerializableConfigViewModel
    {
        private readonly PluginAction _action;

        ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

        private PlayActionConfigModel Configuration { get; }

        public SoundpadSound Sound
        {
            get => Configuration.Sound;
            private set => Configuration.Sound = value;
        }

        public SoundpadCategory Category
        {
            get => Configuration.Category;
            private set => Configuration.Category = value;
        }

        public List<SoundpadCategory> Categories { get; } = new List<SoundpadCategory>();

        public List<SoundpadSound> Sounds { get; } = new List<SoundpadSound>();

        public PlayActionConfigViewModel(PluginAction action)
        {
            Configuration = PlayActionConfigModel.Deserialize(action.Configuration);
            _action = action;
        }

        public SoundpadCategory DefaultCategory => Categories.FirstOrDefault(c => c.Type == 1);
        public void SaveConfig()
        {
            try
            {
                SetConfig();
                MacroDeckLogger.Trace(PluginInstance.Plugin, $"{nameof(PlayActionConfigViewModel)}: config saved");
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Plugin, $"{nameof(PlayActionConfigViewModel)}: config NOT saved");
                MacroDeckLogger.Error(PluginInstance.Plugin, $"{nameof(PlayActionConfigViewModel)}: {ex.Message}");
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
                Sound = Sounds.FirstOrDefault(s => s.Title == audioTitle);
            }
            else if (!(Sound is null)) //load existing configuration
            {
                Sound = Sounds.FirstOrDefault(s => s.Title == Sound.Title) ??
                        Sounds.FirstOrDefault(s => s.Index == Sound.Index);
            }

            if (Sound is null && Configuration.AudioIndex > -1)
            {
                Sound = Sounds.FirstOrDefault(s => s.Index == Configuration.AudioIndex);
            }

            if (Sound != null)
            {
                Configuration.AudioIndex = Sound.Index;
            }
        }

        public void ChangeCategory(string categoryName = default)
        {
            if (!string.IsNullOrEmpty(categoryName))
            {
                Category = Categories.FirstOrDefault(c => c.Name == categoryName);
            }
            else if (!(Category is null)) //load existing configuration
            {
                Category = Categories.FirstOrDefault(c => c.Name == Category.Name) ??
                           Categories.FirstOrDefault(c => c.Index == Category.Index);
            }

            //separate condition in case changed to null (ie. category changed in Name and Index)
            Category ??= DefaultCategory;
        }

        public async Task FetchCategoriesAsync()
        {
            try
            {
                var categoryListResponse = await SoundPadManager.Soundpad.GetCategories();
                Categories.Clear();
                Categories.AddRange(categoryListResponse.Value.Categories.Select(c => new SoundpadCategory(c)));
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Warning(PluginInstance.Plugin,  ExceptionMessage(ex));
            }

        }

        public async Task FetchSoundListAsync(string categoryName = default)
        {
            try
            {
                var soundList = await FetchSoundsAsync(categoryName);
                if (soundList != null)
                {
                    Sounds.Clear();
                    Sounds.AddRange(soundList.Select(s => new SoundpadSound(s)));
                }
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Warning(PluginInstance.Plugin, ExceptionMessage(ex));
            }
        }

        private async Task<List<SoundpadConnector.XML.Sound>> FetchSoundsAsync(string categoryName = default)
        {
            if (string.IsNullOrEmpty(categoryName) || Categories.First(c => c.Name == categoryName).Type == 1)
            {
                var soundlistResponse = await SoundPadManager.Soundpad.GetSoundlist();
                return soundlistResponse.Value.Sounds;
            }
            var category = await SoundPadManager.Soundpad.GetCategory(Categories.First(c => c.Name == categoryName).Index, withSounds: true);
            return category.Value.Sounds;
        }

        private static string ExceptionMessage(Exception ex, [CallerMemberName]string calledBy = default)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}.{1}: {2}", nameof(PlayActionConfigViewModel), calledBy, ex.Message);
            if (ex.InnerException != null)
            {
                sb.AppendFormat(" - {0}", ex.InnerException.Message);
            }
            return sb.ToString();
        }
    }
}
