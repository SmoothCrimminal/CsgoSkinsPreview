namespace CsGoSkinsPreview.Controls;

public partial class CardView : ContentView
{
    #region Bindable Properties
    public static readonly BindableProperty SkinImageSourceProperty = BindableProperty.Create("SkinImageSource", typeof(string), typeof(CardView));
    public static readonly BindableProperty SkinRarityColorProperty = BindableProperty.Create("SkinRarityColor", typeof(string), typeof(CardView));
    public static readonly BindableProperty SkinNameProperty = BindableProperty.Create("SkinName", typeof(string), typeof(CardView));
    public static readonly BindableProperty SkinPriceProperty = BindableProperty.Create("SkinPrice", typeof(string), typeof(CardView));
    public string SkinImageSource
    {
        get { return (string)GetValue(SkinImageSourceProperty); }
        set { SetValue(SkinImageSourceProperty, value); }
    }
    public string SkinRarityColor
    {
        get { return (string)GetValue(SkinRarityColorProperty); }
        set { SetValue(SkinRarityColorProperty, "#" + value); }
    }
    public string SkinName
    {
        get { return (string)GetValue(SkinNameProperty); }
        set { SetValue(SkinNameProperty, value); }
    }
    public string SkinPrice
    {
        get { return (string)GetValue(SkinPriceProperty); }
        private set { SetValue(SkinPriceProperty, value); }
    }
    #endregion
    public CardView()
	{
		InitializeComponent();
	}
}