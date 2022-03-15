using PW.MacroDeck.SoundPad.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PW.MacroDeck.SoundPad.ViewModels
{
    internal interface ISerializableConfigViewModel
    {
        protected ISerializableConfiguration SerializableConfiguration { get; }

        void SetConfig();

        void SaveConfig();
    }
}
