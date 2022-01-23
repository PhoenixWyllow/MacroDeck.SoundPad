namespace PW.MacroDeck.SoundPad.Models
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
        public string PlayActionAudioIndex { get; set; } = "Audio index";
    }
}
