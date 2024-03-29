﻿namespace PW.MacroDeck.SoundPad.Models
{
    internal sealed class Localization
    {
        public string Attribution { get; set; } = "built-in values";
        public string Language { get; set; } = "English (default)";
        public string PluginDescription { get; set; } = "A SoundPad integration for Macro Deck";
        public string Connected { get; set; } = "SoundPad Connected";
        public string Disconnected { get; set; } = "SoundPad Disconnected";
        public string PlayActionName { get; set; } = "Play";
        public string PlayActionDescription { get; set; } = "Play a sound";
        public string PlayActionCategory { get; set; } = "Category";
        public string PlayActionSoundTitle { get; set; } = "Sound title";
        public string PleaseConnect { get; set; } = "Please ensure Soundpad is open and connected, then try again.";
        public string StopPlaybackActionName { get; set; } = "Stop audio";
        public string StopPlaybackActionDescription { get; set; } = "Stops Soundpad audio playback";
        public string StartRecordingActionName { get; set; } = "Start recording";
        public string StartRecordingActionDescription { get; set; } = "Start recording from selected device. Device used is set in Soundpad preferences.";
        public string RecordingDeviceSelection { get; set; } = "Recording device";
        public string RecordingDeviceMicrophone { get; set; } = "Microphone";
        public string RecordingDeviceSpeakers { get; set; } = "Speakers";
        public string StopRecordingActionName { get; set; } = "Stop recording";
        public string StopRecordingActionDescription { get; set; } = "Stops Soundpad recording";
    }
}
