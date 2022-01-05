using SuchByte.MacroDeck.Plugins;
using System.Collections.Generic;
using System.Drawing;
using PW.MacroDeck.SoundPad.Services;
using PW.MacroDeck.SoundPad.Models;
using System;
using SuchByte.MacroDeck.GUI.CustomControls;
using System.Diagnostics;
using System.Windows.Forms;
using PW.MacroDeck.SoundPad.Actions;

namespace PW.MacroDeck.SoundPad
{
    internal static class PluginInstance
    {
        public static MacroDeckPlugin Plugin { get; set; }
        public static ContentSelectorButton ContentButton { get; set; }
    }

    public class SoundPadPlugin : MacroDeckPlugin
    {
        public override string Name => LocalizationManager.Instance.PluginName;

        public override string Description => LocalizationManager.Instance.PluginDescription;

        public override Image Icon => Properties.Resources.SoundPadPluginIcon;

        public override bool CanConfigure => false;

        public override void Enable()
        {
            Actions = new List<PluginAction>
            {
                new PlayAction(),
            };
        }

        public override void OpenConfigurator()
        {
        }

        public SoundPadPlugin()
        {
            PluginInstance.Plugin ??= this;

            LocalizationManager.CreateInstance();

            SuchByte.MacroDeck.MacroDeck.OnMainWindowLoad += MacroDeck_OnMainWindowLoad;

            SoundPadManager.Start();
        }

        private static ToolTip contentButtonToolTip;
        private void MacroDeck_OnMainWindowLoad(object sender, EventArgs e)
        {
            if (sender != null &&
                sender is SuchByte.MacroDeck.GUI.MainWindow mainWindow)
            {
                PluginInstance.ContentButton = new ContentSelectorButton();
                contentButtonToolTip = new ToolTip();
                UpdateContentButton();

                mainWindow.contentButtonPanel.Controls.Add(PluginInstance.ContentButton);
            }

        }

        public static void UpdateContentButton()
        {
            if (PluginInstance.ContentButton != null)
            {
                PluginInstance.ContentButton.BackgroundImage = SoundPadManager.IsConnected ? Properties.Resources.SoundPadConnected : Properties.Resources.SoundPadDisconnected;

                contentButtonToolTip.SetToolTip(PluginInstance.ContentButton, SoundPadManager.IsConnected ? LocalizationManager.Instance.Connected : LocalizationManager.Instance.Disconnected);
            }
        }
    }
}
