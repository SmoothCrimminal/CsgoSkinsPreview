using CsGoSkinsPreview.Remote.Interfaces;

namespace CsGoSkinsPreview;

public partial class App : Application
{
	public App(IApiCaller apiCaller)
	{
		InitializeComponent();

		MainPage = new MainPage(apiCaller);
	}
}
