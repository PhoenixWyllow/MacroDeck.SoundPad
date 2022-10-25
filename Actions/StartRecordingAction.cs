using PW.MacroDeck.SoundPad.Services;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;

namespace PW.MacroDeck.SoundPad.Actions
{
    public sealed class StartRecordingAction : PluginAction
    {
        public override string Name => LocalizationManager.Instance.StartRecordingActionName;

        public override string Description => LocalizationManager.Instance.StartRecordingActionDescription;

        public override bool CanConfigure => true;

        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new Views.RecordActionConfigView(this);
        }

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            SoundPadManager.Record(Configuration);
        }
    }
}
