using PW.MacroDeck.SoundPad.Models;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace PW.MacroDeck.SoundPad.ViewModels
{
    internal class PlayActionConfigViewModel : ISerializableConfigViewModel
    {
        private readonly PluginAction _action;

        ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

        public PlayActionConfigModel Configuration { get; set; }
        public int AudioIndex 
        {
            get => Configuration.AudioIndex;
            set => Configuration.AudioIndex = value;
        }

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
            _action.ConfigurationSummary = Configuration.AudioIndex.ToString();
            _action.Configuration = Configuration.Serialize();
        }
    }
}
