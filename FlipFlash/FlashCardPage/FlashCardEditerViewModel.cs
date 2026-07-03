using Syncfusion.Maui.Toolkit.SegmentedControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static FlipFlash.Models.FlashCard;
using CommunityToolkit.Mvvm.ComponentModel;
using FlipFlash.Services;
using FlipFlash.Models;

namespace FlipFlash.FlashCardPage
{
    public partial class FlashCardEditerViewModel : ObservableObject
    {
        [ObservableProperty()]
        public ObservableCollection<string> _difficultyLevels = new ObservableCollection<string>();
        
        private readonly IFlashCardService _flashCardService;

        [ObservableProperty()]
        public CardContent _cardContent = new CardContent();

        public FlashCardEditerViewModel(IFlashCardService flashCardService)
        {
            DifficultyLevels = new ObservableCollection<string>(
                Enum.GetNames(typeof(DifficultyLevel))
            );

            _flashCardService = flashCardService;

            _cardContent = new CardContent{ Text = "2 + 2" };
        }
    }
}
