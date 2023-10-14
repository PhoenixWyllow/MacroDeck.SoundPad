using System;
using System.Linq;
using System.Collections.Generic;
using PW.MacroDeck.SoundPad.Services;

namespace PW.MacroDeck.SoundPad.Models;

public enum RecordingDevice { Microphone, Speakers }
public static class RecordingDeviceExtensions
{
    public static string AsDisplayString(this RecordingDevice recordingDevice)
    {
        return recordingDevice switch
        {
            RecordingDevice.Microphone => LocalizationManager.Instance.RecordingDeviceMicrophone,
            RecordingDevice.Speakers => LocalizationManager.Instance.RecordingDeviceSpeakers,
            _ => recordingDevice.ToString(),
        };
    }

    public static IEnumerable<string> GetRecordingDevices()
    {
        return Enum.GetValues(typeof(RecordingDevice)).Cast<RecordingDevice>().Select(e => e.AsDisplayString());
    }
}