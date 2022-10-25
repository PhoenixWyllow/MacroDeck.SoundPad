using PW.MacroDeck.SoundPad.Models;

namespace PW.MacroDeck.SoundPad.ViewModels
{
    internal interface ISerializableConfigViewModel
    {
        protected ISerializableConfiguration SerializableConfiguration { get; }

        void SetConfig();

        void SaveConfig();
    }
}
