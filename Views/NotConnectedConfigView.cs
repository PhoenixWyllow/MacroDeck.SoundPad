using PW.MacroDeck.SoundPad.Services;
using SuchByte.MacroDeck.GUI.CustomControls;

namespace PW.MacroDeck.SoundPad.Views
{
    public partial class NotConnectedConfigView : ActionConfigControl
    {
        public NotConnectedConfigView()
        {
            InitializeComponent();
            ApplyLocalization();
        }

        private void ApplyLocalization()
        {
            labelMessage.Text = LocalizationManager.Instance.PleaseConnect;
        }

    }
}
