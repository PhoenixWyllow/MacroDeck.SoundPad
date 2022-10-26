using PW.MacroDeck.SoundPad.Services;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;

namespace PW.MacroDeck.SoundPad.Actions;

public sealed class StopRecordingAction : PluginAction
{
    public override string Name => LocalizationManager.Instance.StopRecordingActionName;

    public override string Description => LocalizationManager.Instance.StopRecordingActionDescription;

    public override bool CanConfigure => false;

    public override void Trigger(string clientId, ActionButton actionButton)
    {
        if (SoundPadManager.IsConnected)
        {
            SoundPadManager.Soundpad.StopRecording();
        }
    }
}