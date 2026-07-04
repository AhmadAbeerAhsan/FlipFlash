namespace FlipFlash.AppSettingsPage;

public partial class AppSettingsView : ContentPage
{
	AppSettingsViewModel _appSettingsViewModel;
	public AppSettingsView(AppSettingsViewModel appSettingsViewModel)
	{
		InitializeComponent();
        BindingContext = _appSettingsViewModel = appSettingsViewModel;
    }
}