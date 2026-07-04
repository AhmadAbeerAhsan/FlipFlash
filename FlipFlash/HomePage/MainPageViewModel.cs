using CommunityToolkit.Mvvm.ComponentModel;
using FlipFlash.Services;
using FlipFlash.FlashCardPage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using FlipFlash.Models.Helpers;
using FlipFlash.CardCollectionPage;

namespace FlipFlash.HomePage
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly ICardCollectionService _cardCollectionService;
        private readonly IFlashCardService _flashCardService;
        private readonly IAppSettingsService _appSettingsService;
        private readonly INavigationService _navigationService;
        public MainPageViewModel(
            ICardCollectionService cardCollectionService,
            IFlashCardService flashCardService,
            IAppSettingsService appSettingsService,
            INavigationService navigationService
        )
        {
            _cardCollectionService = cardCollectionService;
            _flashCardService = flashCardService;
            _appSettingsService = appSettingsService;

            _navigationService = navigationService;
            NavigateToFlashCardEditorView = new Command(async () => await NavigateToFlashCardEditorViewAsync());
            NavigateToAllCardsCollectionViewCommand = new Command(async () => await NavigateToCardCollectionAsync("All", null));
            NavigateToCardCollectionCommand = new Command<string>(async (collectionId) => await NavigateToCardCollectionAsync("Collection", collectionId));
        }

        [ObservableProperty()]
        public int _activeCardCount = 0;

        [ObservableProperty()]
        public int _expireSoonCardsCount = 0;

        [ObservableProperty()]
        public int _expiredCardCount = 0;

        public ObservableCollection<CardCollectionWithFlashCardCount> CardCollections { get; } = [];

        public async Task InitializeAsync()
        {
            var cardCollection = await _cardCollectionService.GetWithFlashCardCountAsync();
            CardCollections.Clear();
            foreach (var collection in cardCollection)
            {
                CardCollections.Add(collection);
            }

            ActiveCardCount = (await _flashCardService.GetExpiresSoonAsync()).Count();
            ExpireSoonCardsCount = (await _flashCardService.GetExpiresTodayAsync()).Count();
            ExpiredCardCount = (await _flashCardService.GetExpiredAsync()).Count();
        }

        public ICommand NavigateToFlashCardEditorView { get; }
        private async Task NavigateToFlashCardEditorViewAsync()
        {
            await _navigationService.GoToAsync(nameof(FlashCardEditerView));
        }

        public ICommand NavigateToAllCardsCollectionViewCommand { get; }
        public ICommand NavigateToCardCollectionCommand { get; }
        private async Task NavigateToCardCollectionAsync(string displayMode, string collectionId)
        {
            await _navigationService.GoToAsync(nameof(CardCollectionView), new Dictionary<string, object>
            {
                { "DisplayMode", displayMode },
                { "CollectionId", collectionId }
            });
        }
    }
}
