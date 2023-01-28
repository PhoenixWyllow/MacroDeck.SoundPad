using PW.MacroDeck.SoundPad.Models;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;

namespace PW.MacroDeck.SoundPad.ViewModels
{
    internal class RecordActionConfigViewModel : ISerializableConfigViewModel
    {
        private readonly PluginAction _action;

        ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

        private RecordActionConfigModel Configuration { get; }

        public RecordingDevice RecordingDevice
        {
            get => Configuration.RecordingDevice;
            set => Configuration.RecordingDevice = value;
        }

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
                MacroDeckLogger.Trace(PluginInstance.Plugin, $"{nameof(RecordActionConfigViewModel)}: config saved");
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Plugin, $"{nameof(RecordActionConfigViewModel)}: config NOT saved");
                MacroDeckLogger.Error(PluginInstance.Plugin, $"{nameof(RecordActionConfigViewModel)}: {ex.Message}");
            }
        }

        public void SetConfig()
        {
            _action.ConfigurationSummary = Configuration.ToString();
            _action.Configuration = Configuration.Serialize();
        }

    }
}
