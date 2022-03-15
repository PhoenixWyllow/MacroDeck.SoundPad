using PW.MacroDeck.SoundPad.Services;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace PW.MacroDeck.SoundPad.Actions
{
    public class StopPlaybackAction : PluginAction
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
}
