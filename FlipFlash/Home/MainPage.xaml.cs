namespace FlipFlash.Home
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _mainPageViewModel;

        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = _mainPageViewModel = mainPageViewModel;
        }
    }
}
