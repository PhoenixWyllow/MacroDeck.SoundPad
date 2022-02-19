using PW.MacroDeck.SoundPad.Models;
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
    public partial class RecordActionConfigView : ActionConfigControl
    {
        private readonly RecordActionConfigViewModel _viewModel;

        public RecordActionConfigView(PluginAction action)
        {
            _viewModel = new RecordActionConfigViewModel(action);

            InitializeComponent();
            ApplyLocalization();
        }

        private void ApplyLocalization()
        {
            labelRecordingDevice.Text = LocalizationManager.Instance.RecordingDeviceSelection;
        }

        public override bool OnActionSave()
        {
            _viewModel.SaveConfig();

            return base.OnActionSave();
        }

        private void PlayActionConfigView_Load(object sender, EventArgs e)
        {
            deviceSelection.Items.Clear();
            deviceSelection.Items.AddRange(RecordingDeviceExtensions.GetRecordingDevices().ToArray());
            deviceSelection.SelectedIndex = (int)_viewModel.RecordingDevice;
        }

        private void DeviceSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            _viewModel.RecordingDevice = (RecordingDevice)deviceSelection.SelectedIndex;
        }
    }
}
