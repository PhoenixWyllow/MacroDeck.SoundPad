using PW.MacroDeck.SoundPad.Models;
using SoundpadConnector;
using SoundpadConnector.Response;
using SoundpadConnector.XML;
using SuchByte.MacroDeck.Variables;
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

            Soundpad.StatusChanged += OnStatusChanged;

            // Note that the API is asynchronous. Make sure that Soundpad is connected before executing commands.
            Soundpad.ConnectAsync();

        }

        private static void OnStatusChanged(object sender, EventArgs e)
        {
            SoundPadPlugin.UpdateContentButton();
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

        public static void Record(string config)
        {
            if (IsConnected)
            {
                var actionConfig = RecordActionConfigModel.Deserialize(config);
                switch (actionConfig.RecordingDevice)
                {
                    case RecordingDevice.Microphone:
                        Soundpad.StartRecordingMicrophone();
                        break;
                    case RecordingDevice.Speakers:
                        Soundpad.StartRecordingSpeakers();
                        break;
                    default:
                        Soundpad.StartRecording();
                        break;
                }
            }
        }
    }
}
