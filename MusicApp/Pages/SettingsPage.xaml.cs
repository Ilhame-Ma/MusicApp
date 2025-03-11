using MusicApp.PageModels;

namespace MusicApp.Pages;

public partial class SettingsPage : ContentPage
{
    private readonly SettingsViewModel _viewModel;

    public SettingsPage()
    {
        InitializeComponent();
        _viewModel = new MusicApp.PageModels.SettingsViewModel();
        BindingContext = _viewModel;
    }

    private void OnDarkModeToggled(object sender, ToggledEventArgs e)
    {
        if (_viewModel != null)
        {
            _viewModel.IsDarkMode = e.Value;
            _viewModel.ToggleDarkMode();
        }
    }
}
