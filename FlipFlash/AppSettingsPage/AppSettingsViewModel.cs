using CommunityToolkit.Mvvm.ComponentModel;
using FlipFlash.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlipFlash.AppSettingsPage
{
    public partial class AppSettingsViewModel : ObservableObject
    {
        private readonly IAppSettingsService _appSettingsService;

        public AppSettingsViewModel(IAppSettingsService appSettingsService)
        {
            _appSettingsService = appSettingsService;
        }
    }
}
