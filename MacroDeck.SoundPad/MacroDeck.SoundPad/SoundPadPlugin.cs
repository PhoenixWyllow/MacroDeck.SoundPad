using SuchByte.MacroDeck.Plugins;
using System.Collections.Generic;
using System.Drawing;
using PW.MacroDeck.SoundPad.Services;
using PW.MacroDeck.SoundPad.Models;
using System;
using SuchByte.MacroDeck.GUI.CustomControls;
using System.Diagnostics;
using System.Windows.Forms;

namespace PW.MacroDeck.SoundPad
{
    internal static class PluginInstance
    {
        public static MacroDeckPlugin Plugin { get; set; }
        public static ContentSelectorButton ContentButton { get; set; }
    }

    public class SoundPadPlugin : MacroDeckPlugin
    {
        /// <summary>
        /// Short description what the plugin can do
        /// </summary>
        public override string Description => LocalizationManager.Instance.PluginDescription;

        /// <summary>
        /// Icon for the plugin
        /// </summary>
        public override Image Icon => Properties.Resources.MacroDeckSoundPad;

        /// <summary>
        /// Can the plugin be configured? E.g. accounts
        /// </summary>
        public override bool CanConfigure => false;

        /// <summary>
        /// Gets called when Macro Deck enables the plugin
        /// </summary>
        public override void Enable()
        {
            Actions = new List<PluginAction>
            {
            };
        }

        /// <summary>
        /// Gets called when the user wants to configure the plugin
        /// </summary>
        public override void OpenConfigurator()
        {
        }

        public SoundPadPlugin()
        {
            LocalizationManager.CreateInstance();
            SoundPadManager.Start();

            PluginInstance.Plugin ??= this;

            SuchByte.MacroDeck.MacroDeck.OnMainWindowLoad += MacroDeck_OnMainWindowLoad;
        }
        private void MacroDeck_OnMainWindowLoad(object sender, EventArgs e)
        {
            if (sender != null &&
                sender is SuchByte.MacroDeck.GUI.MainWindow mainWindow)
            {
                var statusButton = PluginInstance.ContentButton = new ContentSelectorButton();
                statusButton.BackgroundImage = Properties.Resources.SoundPadDisconnected;
                mainWindow.contentButtonPanel.Controls.Add(statusButton);
            }
#if DEBUG
            else
            {
                System.IO.File.WriteAllText(
                    System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "SoundpadDebug.txt"), 
                    $"Sender:{sender is null}, {sender?.GetType()}");
            }
#endif

        }
    }
}
