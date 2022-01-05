namespace PW.MacroDeck.SoundPad.Models
{
    internal sealed class Localization
    {
        public string Attribution { get; set; } = "built-in values";
        public string Language { get; set; } = "English (default)";
        public string PluginName { get; set; } = "SoundPad plugin";
        public string PluginDescription { get; set; } = "A SoundPad integration for Macro Deck";
        public string Connected { get; set; } = "SoundPad Connected";
        public string Disconnected { get; set; } = "SoundPad Disconnected";
        public string SyncButtonState { get; set; } = "Sync button state";
        public string PlayStopActionName { get; set; } = "Play or Stop";
        public string PlayStopActionDescription { get; set; } = "Play or Stop a sound";
    }
}
