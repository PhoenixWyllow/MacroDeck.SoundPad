using PW.MacroDeck.SoundPad.Models;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;

namespace PW.MacroDeck.SoundPad.ViewModels
{
    internal class RecordActionConfigViewModel : ISerializableConfigViewModel
    {
        private readonly PluginAction _action;

        ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

        public RecordActionConfigModel Configuration { get; set; }

        public RecordingDevice RecordingDevice
        {
            get => Configuration.RecordingDevice;
            set => Configuration.RecordingDevice = value;
        }

        public List<SoundpadCategory> Categories { get; set; }

        public List<SoundpadSound> Sounds { get; set; }

        public RecordActionConfigViewModel(PluginAction action)
        {
            Configuration = RecordActionConfigModel.Deserialize(action.Configuration);
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

    }
}
