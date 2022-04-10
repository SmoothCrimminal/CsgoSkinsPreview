using System.Windows.Input;

namespace CsGoSkinsPreview.Controls;

public partial class SearchBar : ContentView
{
    #region Dependency Properties
    public static readonly BindableProperty WeaponTypesProperty = BindableProperty.Create("WeaponTypes", typeof(List<string>), typeof(SearchBar));
    public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create("SearchCommand", typeof(ICommand), typeof(SearchBar));
    public List<string> WeaponTypes
    {
        get => (List<string>)GetValue(WeaponTypesProperty);
        set => SetValue(WeaponTypesProperty, value);
    }
    public ICommand SearchCommand
    {
        get => (ICommand)GetValue(SearchCommandProperty);
        set => SetValue(SearchCommandProperty, value);
    }
    #endregion
    public SearchBar()
	{
		InitializeComponent();
	}
}