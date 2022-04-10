using CsGoSkinsPreview.Remote.Interfaces;
using CsGoSkinsPreview.ViewModels;

namespace CsGoSkinsPreview;

public partial class MainPage : ContentPage
{
	private readonly MainPageVM _mainPageVM;
	public MainPage(IApiCaller apiCaller)
	{
		_mainPageVM = new(apiCaller, this);
		BindingContext = _mainPageVM;
		_mainPageVM?.Initialize();
		InitializeComponent();
	}

    private async void SearchButton_Clicked(object sender, EventArgs e)
    {
		await _mainPageVM?.SearchCommandExecute();
	}
}

