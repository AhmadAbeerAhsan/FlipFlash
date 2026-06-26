using Syncfusion.Maui.Toolkit.SegmentedControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static FlipFlash.FlashCard.FlashCard;
using CommunityToolkit.Mvvm.ComponentModel;
using FlipFlash.Services;

namespace FlipFlash.FlashCard
{
    public partial class FlashCardEditerViewModel : ObservableObject
    {
        [ObservableProperty()]
        public ObservableCollection<string> _difficultyLevels = new ObservableCollection<string>();
        
        private readonly IFlashCardService _flashCardService;
        public FlashCardEditerViewModel(IFlashCardService flashCardService)
        {
            _difficultyLevels = new ObservableCollection<string>(
                Enum.GetNames(typeof(DifficultyLevel))
            );

            _flashCardService = flashCardService;
        }
    }
}
