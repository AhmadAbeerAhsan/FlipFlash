using Syncfusion.Maui.Toolkit.SegmentedControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static FlipFlash.Card.Card;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FlipFlash.Card
{
    public partial class CardEditerViewModel : ObservableObject
    {
        [ObservableProperty()]
        public ObservableCollection<string> _difficultyLevels = new ObservableCollection<string>();

        [ObservableProperty()]
        public ObservableCollection<SfSegmentItem> _inputOptions = new ObservableCollection<SfSegmentItem>();
        public CardEditerViewModel()
        {
            _difficultyLevels = new ObservableCollection<string>(
                Enum.GetNames(typeof(DifficultyLevel))
            );

            _inputOptions = new ObservableCollection<SfSegmentItem>()
            {
                    new SfSegmentItem(){ImageSource="text.png", Text="Text" },
                    new SfSegmentItem(){ImageSource="camera.png", Text="Camera" },
                    new SfSegmentItem(){ImageSource="mic.png", Text="Audio" },
            };
        }
    }
}
