using PW.MacroDeck.SoundPad.Services;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;

namespace PW.MacroDeck.SoundPad.Actions
{
    public sealed class PlayAction : PluginAction
    {
        public override string Name => LocalizationManager.Instance.PlayActionName;

        public override string Description => LocalizationManager.Instance.PlayActionDescription;

        public override bool CanConfigure => true;

        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            if (!SoundPadManager.IsConnected)
            {
                return new Views.NotConnectedConfigView();
            }
            return new Views.PlayActionConfigView(this);
        }

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            SoundPadManager.Play(Configuration);
        }
    }
}
