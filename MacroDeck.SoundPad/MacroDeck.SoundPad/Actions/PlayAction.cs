using PW.MacroDeck.SoundPad.Services;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace PW.MacroDeck.SoundPad.Actions
{
    public class PlayAction : PluginAction
    {
        public override string Name => LocalizationManager.Instance.PlayStopActionName;

        public override string Description => LocalizationManager.Instance.PlayStopActionDescription;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            SoundPadManager.Play(1);
        }
    }
}
