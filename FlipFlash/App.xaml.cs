using Microsoft.Extensions.DependencyInjection;

namespace FlipFlash
{
    public partial class App : Application
    {
        AppShellViewModel _appShellViewModel;
        public App()
        {
            InitializeComponent();
            BindingContext = _appShellViewModel = new AppShellViewModel();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}