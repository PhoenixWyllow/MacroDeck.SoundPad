using PW.MacroDeck.SoundPad.Services;
using PW.MacroDeck.SoundPad.ViewModels;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PW.MacroDeck.SoundPad.Views;

public partial class PlayActionConfigView : ActionConfigControl
{
    private readonly PlayActionConfigViewModel _viewModel;
    private bool _isBusy = false;
    public PlayActionConfigView(PluginAction action)
    {
        _viewModel = new(action);

        InitializeComponent();
        ApplyLocalization();
    }

    private void ApplyLocalization()
    {
        labelCategory.Text = LocalizationManager.Instance.PlayActionCategory;
        labelSoundTitle.Text = LocalizationManager.Instance.PlayActionSoundTitle;
    }

    public override bool OnActionSave()
    {
        _viewModel.SaveConfig();

        return base.OnActionSave();
    }

    private async void PlayActionConfigView_Load(object sender, EventArgs e)
    {
        await _viewModel.FetchCategoriesAsync();
        categoryNames.Items.Clear();
        categoryNames.Items.AddRange(_viewModel.Categories.Select(c => c.Name).ToArray());
        _viewModel.ChangeCategory();
        _isBusy = true;
        if (_viewModel.Category != null)
        {
            categoryNames.SelectedItem = _viewModel.Category.Name; //calls CategoryNames_SelectedIndexChanged
        }
        else
        {
            await GetSoundListAsync();
        }
        while (_isBusy) //Poll _isBusy until previous call is finished otherwise ChangeSound breaks due to null exception. 
        {
            await Task.Delay(25);
        }
        _viewModel.ChangeSound();
        if (_viewModel.Sound != null)
        {
            audioTitles.SelectedItem = _viewModel.Sound.Title; //calls AudioTitles_SelectedIndexChanged
        }
    }

    private async void CategoryNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        _viewModel.ChangeCategory((string)categoryNames.SelectedItem);
        await GetSoundListAsync();
    }

    private async Task GetSoundListAsync()
    {
        await _viewModel.FetchSoundListAsync();
        audioTitles.Items.Clear();
        audioTitles.Items.AddRange(_viewModel.Sounds.Select(a => a.Title).ToArray());
        _isBusy = false;
    }

    private void AudioTitles_SelectedIndexChanged(object sender, EventArgs e)
    {
        _viewModel.ChangeSound((string)audioTitles.SelectedItem);
    }
}