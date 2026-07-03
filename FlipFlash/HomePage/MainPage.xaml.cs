namespace FlipFlash.HomePage
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _mainPageViewModel;

        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = _mainPageViewModel = mainPageViewModel;
        }

        protected async override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            await _mainPageViewModel.InitializeAsync();
            base.OnNavigatedTo(args);
        }
    }
}
