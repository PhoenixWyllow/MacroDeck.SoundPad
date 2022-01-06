using PW.MacroDeck.SoundPad.Services;
using PW.MacroDeck.SoundPad.ViewModels;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PW.MacroDeck.SoundPad.Views
{
    public partial class PlayActionConfigView : ActionConfigControl
    {
        private readonly PlayActionConfigViewModel _viewModel;
        public PlayActionConfigView(PluginAction action)
        {
            _viewModel = new PlayActionConfigViewModel(action);

            InitializeComponent();
            ApplyLocalization();
        }

        private void ApplyLocalization()
        {
            audioIndexLabel.Text = LocalizationManager.Instance.PlayActionAudioIndex;
        }

        public override bool OnActionSave()
        {
            _viewModel.SaveConfig();

            return base.OnActionSave();
        }

        private void PlayActionConfigView_Load(object sender, EventArgs e)
        {
            audioIndex.Value = _viewModel.AudioIndex;
        }

        private void AudioIndex_ValueChanged(object sender, EventArgs e)
        {
            _viewModel.AudioIndex = (int)audioIndex.Value;
        }
    }
}
