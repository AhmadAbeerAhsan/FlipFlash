namespace FlipFlash.FlashCardPage;

[QueryProperty(nameof(FlashCardId), nameof(FlashCardId))]
public partial class FlashCardEditerView : ContentPage
{
	private readonly FlashCardEditerViewModel _flashCardEditerViewModel;
	public FlashCardEditerView(FlashCardEditerViewModel flashCardEditerViewModel)
	{
		InitializeComponent();
		BindingContext = _flashCardEditerViewModel = flashCardEditerViewModel;
    }

    public string? FlashCardId { get; set; }

	override protected async void OnNavigatedTo(NavigatedToEventArgs args)
    {
		await _flashCardEditerViewModel.InitializeAsync(FlashCardId);
		base.OnNavigatedTo(args);
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
		await _flashCardEditerViewModel.SaveFlashCardAsync();
    }
}