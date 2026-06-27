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

        [ObservableProperty()]
        public int _activeCardCount = 0;

        [ObservableProperty()]
        public int _expireSoonCardsCount = 0;

        [ObservableProperty()]
        public int _expiredCardCount = 0;

        public async Task InitializeAsync()
        {
            ActiveCardCount = (await _flashCardService.GetExpiresSoonAsync()).Count();
            ExpireSoonCardsCount = (await _flashCardService.GetExpiresTodayAsync()).Count();
            ExpiredCardCount = (await _flashCardService.GetExpiredAsync()).Count();
        }
    }
}
