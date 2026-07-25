using PW.MacroDeck.SoundPad.Models;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using PW.MacroDeck.SoundPad.Services;

namespace PW.MacroDeck.SoundPad.ViewModels;

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
        }
        catch (Exception ex)
        {
            PluginLogger.Warning(nameof(RecordActionConfigViewModel), "config NOT saved - {ExceptionMessage}", ex.Message);
            PluginLogger.DebugException(ex);
        }
    }

    public void SetConfig()
    {
        _action.ConfigurationSummary = Configuration.ToString();
        _action.Configuration = Configuration.Serialize();
        _action.BindableVariable = SoundPadManager.IsRecordingVariable;
    }

}