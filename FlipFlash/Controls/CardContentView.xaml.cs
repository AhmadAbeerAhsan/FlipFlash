using Syncfusion.Maui.Toolkit.TabView;

namespace FlipFlash.Controls;

public partial class CardContentView : ContentView
{
	public CardContentView()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty CardContentProperty =
        BindableProperty.Create(
            nameof(CardContent),
            typeof(Models.CardContent),
            typeof(DashboardTile),
            new Models.CardContent { Text = string.Empty }
        );

    public Models.CardContent CardContent
    {
        get => (Models.CardContent)GetValue(CardContentProperty);
        set => SetValue(CardContentProperty, value);
    }

    public static readonly BindableProperty PlaceholderProperty =
        BindableProperty.Create(
            nameof(Placeholder),
            typeof(string),
            typeof(DashboardTile)
        );
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public static readonly BindableProperty TopLeftLabelProperty =
        BindableProperty.Create(
            nameof(TopLeftLabel),
            typeof(string),
            typeof(DashboardTile),
            string.Empty
        );
    public string TopLeftLabel
    {
        get => (string)GetValue(TopLeftLabelProperty);
        set => SetValue(TopLeftLabelProperty, value);
    }

    public static readonly BindableProperty TopRightLabelProperty =
        BindableProperty.Create(
            nameof(TopRightLabel),
            typeof(string),
            typeof(DashboardTile),
            string.Empty
        );
    public string TopRightLabel
    {
        get => (string)GetValue(TopRightLabelProperty);
        set => SetValue(TopRightLabelProperty, value);
    }

    public static readonly BindableProperty TopLeftLabelColorProperty =
        BindableProperty.Create(
            nameof(TopLeftLabelColor),
            typeof(Color),
            typeof(DashboardTile),
            Colors.Black
        );
    public Color TopLeftLabelColor
    {
        get => (Color)GetValue(TopLeftLabelColorProperty);
        set => SetValue(TopLeftLabelColorProperty, value);
    }

    public static readonly BindableProperty TopRightLabelColorProperty =
        BindableProperty.Create(
            nameof(TopRightLabelColor),
            typeof(Color),
            typeof(DashboardTile),
            Colors.Black
        );
    public Color TopRightLabelColor
    {
        get => (Color)GetValue(TopRightLabelColorProperty);
        set => SetValue(TopRightLabelColorProperty, value);
    }

}