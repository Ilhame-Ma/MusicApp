using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;
using MusicApp.PageModels;

namespace MusicApp.Pages;

public partial class PlayPage : ContentPage
{
    public PlayPage(PlayPageModel pageModel)
    {
        InitializeComponent();
        BindingContext = pageModel;
    }
}
