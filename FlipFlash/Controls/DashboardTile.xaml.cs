using System.Windows.Input;

namespace FlipFlash.Controls;

public partial class DashboardTile : ContentView
{
    public DashboardTile()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty IconProperty =
        BindableProperty.Create(
            nameof(Icon),
            typeof(string),
            typeof(DashboardTile)
        );
    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public static readonly BindableProperty CountProperty =
        BindableProperty.Create(
            nameof(Count),
            typeof(string),
            typeof(DashboardTile)
        );
    public string Count
    {
        get => (string)GetValue(CountProperty);
        set => SetValue(CountProperty, value);
    }

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(DashboardTile)
        );
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty TileForegroundProperty =
        BindableProperty.Create(
            nameof(TileForeground),
            typeof(Color),
            typeof(DashboardTile),
            Colors.Black
        );
    public Color TileForeground
    {
        get => (Color)GetValue(TileForegroundProperty);
        set => SetValue(TileForegroundProperty, value);
    }

    public static readonly BindableProperty TileBackgroundProperty =
        BindableProperty.Create(
            nameof(TileBackground),
            typeof(Color),
            typeof(DashboardTile),
            Colors.White
        );
    public Color TileBackground
    {
        get => (Color)GetValue(TileBackgroundProperty);
        set => SetValue(TileBackgroundProperty, value);
    }

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(DashboardTile)
        );
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
}