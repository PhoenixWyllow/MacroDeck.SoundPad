using PW.MacroDeck.SoundPad.Actions;
using PW.MacroDeck.SoundPad.Services;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Windows.Forms;

namespace PW.MacroDeck.SoundPad;

internal static class PluginInstance
{
    public static MacroDeckPlugin Plugin { get; set; }
    public static ContentSelectorButton ContentButton { get; set; }
}

public class SoundPadPlugin : MacroDeckPlugin
{
    public override bool CanConfigure => false;

    public override void Enable()
    {
        LocalizationManager.CreateInstance();

        SoundPadManager.Start();

        Actions = [
            new PlayAction(),
            new StopPlaybackAction(),
            new StartRecordingAction(),
            new StopRecordingAction(),
        ];
    }

    public override void OpenConfigurator()
    {
    }

    public SoundPadPlugin()
    {
        PluginInstance.Plugin ??= this;

        SuchByte.MacroDeck.MacroDeck.OnMainWindowLoad += MacroDeck_OnMainWindowLoad;
    }

    private static ToolTip _contentButtonToolTip;
    private void MacroDeck_OnMainWindowLoad(object sender, EventArgs e)
    {
        if (sender != null &&
            sender is SuchByte.MacroDeck.GUI.MainWindow mainWindow)
        {
            PluginInstance.ContentButton = new();
            _contentButtonToolTip = new();
            UpdateContentButton();

            mainWindow.contentButtonPanel.Controls.Add(PluginInstance.ContentButton);
        }
    }

    public static void UpdateContentButton()
    {
        var contentButton = PluginInstance.ContentButton;
        if (contentButton is null || contentButton.IsDisposed)
        {
            return;
        }

        if (contentButton.InvokeRequired)
        {
            contentButton.BeginInvoke((Action)UpdateContentButton);
            return;
        }

        contentButton.BackgroundImage = SoundPadManager.IsConnected ? Properties.Resources.SoundPadConnected : Properties.Resources.SoundPadDisconnected;
        _contentButtonToolTip.SetToolTip(contentButton, SoundPadManager.IsConnected ? LocalizationManager.Instance.Connected : LocalizationManager.Instance.Disconnected);
    }
}