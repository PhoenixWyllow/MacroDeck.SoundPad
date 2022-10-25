using System.Diagnostics;

namespace PW.MacroDeck.SoundPad.Models
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public sealed class SoundpadSound
    {
        public int Index { get; set; }

        public string Title { get; set; }

        public SoundpadSound() { } //required for serialization in config model

        public SoundpadSound(SoundpadConnector.XML.Sound sound)
        {
            Index = sound.Index;
            Title = sound.Title;
        }

        private string GetDebuggerDisplay()
        {
            return $"{Index}: {Title}";
        }
    }
}
