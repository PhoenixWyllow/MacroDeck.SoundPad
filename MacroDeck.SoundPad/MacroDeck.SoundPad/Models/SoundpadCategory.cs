using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PW.MacroDeck.SoundPad.Models
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class SoundpadCategory
    {
        public int Index { get; set; }

        public string Name { get; set; }

        public int Type { get; set; }

        public SoundpadCategory() { } //required for serialization in config model

        public SoundpadCategory(SoundpadConnector.XML.Category category)
        {
            Index = category.Index;
            Name = category.Name;
            Type = category.Type;
        }

        private string GetDebuggerDisplay()
        {
            return $"{Index}. {Name} - {Type}";
        }
    }
}
