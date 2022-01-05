using SoundpadConnector;
using System;
using System.Collections.Generic;
using System.Text;

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

            Console.ReadLine();

        }

        private static void SoundpadOnStatusChanged(object sender, EventArgs e)
        {
            PluginInstance.ContentButton.BackgroundImage = IsConnected ? Properties.Resources.SoundPadConnected : Properties.Resources.SoundPadDisconnected;
        }
    }
}
