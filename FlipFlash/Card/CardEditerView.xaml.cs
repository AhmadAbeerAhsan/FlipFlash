namespace FlipFlash.Card;

public partial class CardEditerView : ContentPage
{
	private readonly CardEditerViewModel _cardEditerViewModel;
	public CardEditerView()
	{
		InitializeComponent();
		BindingContext = _cardEditerViewModel = new CardEditerViewModel();
	}

    
}