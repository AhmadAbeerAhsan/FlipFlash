using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlipFlash
{
    public partial class AppShellViewModel : ObservableObject
    {
        [ObservableProperty()]
        public string _fullName = "Abeer Ahsan";
        [ObservableProperty()]
        public string _initials = "AM";
    }
}
