using PW.MacroDeck.SoundPad.Services;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;

namespace PW.MacroDeck.SoundPad.Actions;

public sealed class StopPlaybackAction : PluginAction
{
    public override string Name => LocalizationManager.Instance.StopPlaybackActionName;

    public override string Description => LocalizationManager.Instance.StopPlaybackActionDescription;

    public override bool CanConfigure => false;

    public override void Trigger(string clientId, ActionButton actionButton)
    {
        if (SoundPadManager.IsConnected)
        {
            SoundPadManager.Soundpad.StopSound();
        }
    }
}