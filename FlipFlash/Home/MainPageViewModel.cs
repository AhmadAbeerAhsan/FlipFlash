using CommunityToolkit.Mvvm.ComponentModel;
using FlipFlash.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlipFlash.Home
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly ICardCollectionService _cardCollectionService;
        private readonly IFlashCardService _flashCardService;
        public MainPageViewModel(ICardCollectionService cardCollectionService, IFlashCardService flashCardService) 
        {
            _cardCollectionService = cardCollectionService;
            _flashCardService = flashCardService;
        }
    }
}
