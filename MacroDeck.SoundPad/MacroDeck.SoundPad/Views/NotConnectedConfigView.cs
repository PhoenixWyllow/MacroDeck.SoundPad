using PW.MacroDeck.SoundPad.Services;
using PW.MacroDeck.SoundPad.ViewModels;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
