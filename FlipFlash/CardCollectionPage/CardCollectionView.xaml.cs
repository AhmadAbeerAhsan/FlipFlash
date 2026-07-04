namespace FlipFlash.CardCollectionPage;

[QueryProperty(nameof(DisplayMode), "DisplayMode")]
[QueryProperty(nameof(CollectionId), "CollectionId")]
public partial class CardCollectionView : ContentPage
{
    private readonly CardCollectionViewModel _viewModel;
    public CardCollectionView(CardCollectionViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    public string DisplayMode { get; set; }
	public string CollectionId { get; set; }

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        if (BindingContext is CardCollectionViewModel viewModel)
        {
            await viewModel.InitializeAsync(DisplayMode, CollectionId);
        }
    }
}