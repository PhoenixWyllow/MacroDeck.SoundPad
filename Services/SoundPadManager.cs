using PW.MacroDeck.SoundPad.Models;
using SoundpadConnector;
using SoundpadConnector.Response;
using SuchByte.MacroDeck.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoundpadConnector.XML;

namespace PW.MacroDeck.SoundPad.Services;

public static class SoundPadManager
{
    private const string PlayVariableFormat = "soundpad_{0}_playing";
    public const string IsRecordingVariable = "soundpad_recording";

    private static Soundpad Soundpad { get; set; }

    public static bool IsConnected => Soundpad is { ConnectionStatus: ConnectionStatus.Connected };
    public static int CurrentSoundIndex { get; set; }

    public static string GetIsPlayingIdVariable(int index) => string.Format(PlayVariableFormat, index);

    public static void Start()
    {
        SetRecordingVariable(false);
        SetPlayStatus(false);

        Soundpad = new()
        {
            AutoReconnect = true,
        };

        Soundpad.StatusChanged += OnStatusChanged;
        Soundpad.Connected += (_, _) => DoPoll();

        // Note that the API is asynchronous. Make sure that Soundpad is connected before executing commands.
        Soundpad.ConnectAsync();
    }

    private static void OnStatusChanged(object sender, EventArgs e)
    {
        SoundPadPlugin.UpdateContentButton();
    }

    public static void Play(string config)
    {
        if (IsConnected)
        {
            var actionConfig = PlayActionConfigModel.Deserialize(config);
            CurrentSoundIndex = actionConfig.Sound?.Index ?? actionConfig.AudioIndex;
            Soundpad.PlaySound(CurrentSoundIndex);
        }
    }

    public static void Record(string config)
    {
        if (IsConnected)
        {
            var actionConfig = RecordActionConfigModel.Deserialize(config);
            switch (actionConfig.RecordingDevice)
            {
                case RecordingDevice.Microphone:
                    Soundpad.StartRecordingMicrophone();
                    break;
                case RecordingDevice.Speakers:
                    Soundpad.StartRecordingSpeakers();
                    break;
                default:
                    Soundpad.StartRecording();
                    break;
            }
        }
    }

    public static void StopRecording()
    {
        if (IsConnected)
        {
            Soundpad.StopRecording();
        }

    }

    public static void StopSound()
    {
        if (IsConnected)
        {
            Soundpad.StopSound();
        }
    }

    public static async Task<List<SoundpadCategory>> GetCategoriesListAsync()
    {
        var categories = await Soundpad.GetCategories();
        return categories.Value.Categories.Select(c => new SoundpadCategory(c)).ToList();
    }

    public static async Task<List<Sound>> GetSoundListAsync(int index)
    {
        var category = await Soundpad.GetCategory(index, withSounds: true);
        return category.Value.Sounds;
    }

    public static async Task<List<Sound>> GetSoundListAsync()
    {
        var soundList = await Soundpad.GetSoundlist();
        return soundList.Value.Sounds;
    }
    private static async Task SetVariables()
    {
        if (IsConnected)
        {
            var responseCount = await Soundpad.GetSoundlist();
            if (responseCount.IsSuccessful)
            {
                var vars = VariableManager.GetVariables(PluginInstance.Plugin);
                vars.ForEach(v => { VariableManager.DeleteVariable(v.Name); });
                var count = responseCount.Value.Sounds.Count;
                for (var i = 1; i <= count; i++)
                {
                    SetBoolVariable(GetIsPlayingIdVariable(i), false);
                }
            }
        }
    }

    private static async void DoPoll()
    {
        await SetVariables();
        while (Soundpad.ConnectionStatus == ConnectionStatus.Connected)
        {
            try
            {
                var response = await Soundpad.IsAlive();
                if (response.IsSuccessful)
                {
                    await UpdateVariables();
                }

            }
            catch
            {
                //do nothing.
            }
            await Task.Delay(Soundpad.PollingInterval);
        }
    }

    private static async Task UpdateVariables()
    {
        var recPos = await Soundpad.GetRecordingPosition();
        SetRecordingVariable(recPos.Value != 0);

        var playStatus = await Soundpad.GetPlayStatus();
        SetPlayStatus(playStatus.Value != PlayStatus.Stopped);
    }

    private static void SetRecordingVariable(bool isRecording)
    {
        SetBoolVariable(IsRecordingVariable, isRecording);
    }

    private static void SetPlayStatus(bool statusValue)
    {
        string currentPlayVar = !CurrentSoundIndex.Equals(int.MinValue) ? GetIsPlayingIdVariable(CurrentSoundIndex) : string.Empty;

        if (!string.IsNullOrEmpty(currentPlayVar))
        {
            SetBoolVariable(currentPlayVar, statusValue);
        }
        foreach (var variable in VariableManager.GetVariables(PluginInstance.Plugin)
                     .Where(v => v.Name != IsRecordingVariable && v.Name != currentPlayVar && v.Value == bool.TrueString))
        {
            SetBoolVariable(variable.Name, false);
        }
    }

    private static void SetBoolVariable(string currentPlayVar, bool statusValue)
    {
        VariableManager.SetValue(currentPlayVar, statusValue, VariableType.Bool, PluginInstance.Plugin);
    }
}