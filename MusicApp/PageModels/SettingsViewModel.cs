using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MusicApp.PageModels;

public partial class SettingsViewModel : ObservableObject
{
    [ObservableProperty]
    private bool isDarkMode;

    public SettingsViewModel()
    {
        IsDarkMode = Preferences.Get("DarkMode", false);
    }

    [RelayCommand]
    public void ToggleDarkMode()
    {
        Preferences.Set("DarkMode", IsDarkMode);
        ApplyTheme();
    }

    private void ApplyTheme()
    {
        App.Current.UserAppTheme = IsDarkMode ? AppTheme.Dark : AppTheme.Light;
    }
}
