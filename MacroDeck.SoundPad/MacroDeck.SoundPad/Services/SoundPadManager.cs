using PW.MacroDeck.SoundPad.Models;
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

            Soundpad.StatusChanged += (_, __) => SoundPadPlugin.UpdateContentButton();

            // Note that the API is asynchronous. Make sure that Soundpad is connected before executing commands.
            Soundpad.ConnectAsync();

        }

        public static void Play(string config)
        {
            if (IsConnected)
            {
                var actionConfig = PlayActionConfigModel.Deserialize(config);
                int index = actionConfig.Sound?.Index ?? actionConfig.AudioIndex;
                Soundpad.PlaySound(index);
            }
        }
    }
}
