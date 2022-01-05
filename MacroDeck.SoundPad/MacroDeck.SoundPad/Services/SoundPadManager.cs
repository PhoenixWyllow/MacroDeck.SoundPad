using SoundpadConnector;
using SoundpadConnector.Response;
using SoundpadConnector.XML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PW.MacroDeck.SoundPad.Services
{
    public sealed class SoundPadManager
    {
        public static Soundpad Soundpad { get; private set; }

        public static bool IsConnected => Soundpad != null && Soundpad.ConnectionStatus == ConnectionStatus.Connected;

        public static void Start()
        {
            Soundpad = new Soundpad()
            { 
                AutoReconnect = true,
            };

            Soundpad.StatusChanged += SoundpadOnStatusChanged;

            // Note that the API is asynchronous. Make sure that Soundpad is connected before executing commands.
            Soundpad.ConnectAsync();

        }

        private static void SoundpadOnStatusChanged(object sender, EventArgs e)
        {
            if (PluginInstance.ContentButton != null)
            {
                PluginInstance.ContentButton.BackgroundImage = IsConnected ? Properties.Resources.SoundPadConnected : Properties.Resources.SoundPadDisconnected;
                
                new System.Windows.Forms.ToolTip()
                    .SetToolTip(PluginInstance.ContentButton, IsConnected ? LocalizationManager.Instance.Connected : LocalizationManager.Instance.Disconnected);
            }
        }

        public static void Play(int index)
        {
            if (IsConnected)
            {
                Soundpad.PlaySound(index);
            }
        }
    }
}
