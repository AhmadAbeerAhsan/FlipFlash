namespace FlipFlash.FlashCard;

public partial class FlashCardEditerView : ContentPage
{
	private readonly FlashCardEditerViewModel _flashCardEditerViewModel;
	public FlashCardEditerView(FlashCardEditerViewModel flashCardEditerViewModel)
	{
		InitializeComponent();
		BindingContext = _flashCardEditerViewModel = flashCardEditerViewModel;
	}

    
}