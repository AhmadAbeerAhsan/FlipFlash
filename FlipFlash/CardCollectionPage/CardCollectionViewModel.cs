using CommunityToolkit.Mvvm.ComponentModel;
using FlipFlash.FlashCardPage;
using FlipFlash.Models;
using FlipFlash.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FlipFlash.CardCollectionPage
{
    public partial class CardCollectionViewModel : ObservableObject
    {
        [ObservableProperty()]
        private string _title;

        public ObservableCollection<FlashCard> FlashCards { get; } = [];

        private readonly ICardCollectionService _cardCollectionService;
        private readonly INavigationService _navigationService;
        private readonly IFlashCardService _flashCardService;

        public CardCollectionViewModel(
            ICardCollectionService cardCollectionService,
            INavigationService navigationService,
            IFlashCardService flashCardService
        )
        {
            _cardCollectionService = cardCollectionService;
            _flashCardService = flashCardService;
            _navigationService = navigationService;

            NavigateToFlashCardEditorViewCommand = new Command<FlashCard>(async (flashCard) => await NavigateToFlashCardEditorViewAsync(flashCard));
        }

        public async Task InitializeAsync(string displayMode, string collectionId)
        {
            IEnumerable<FlashCard> flashCards;

            switch (displayMode)
            {
                case "Collection":
                    flashCards = await _flashCardService.GetByLocationAsync(collectionId);
                    var cardCollection = await _cardCollectionService.GetByIdAsync(collectionId);
                    Title = cardCollection?.Name ?? "Unknown Collection";
                    break;
                default:
                    flashCards = await _flashCardService.GetAsync();
                    Title = "All Flash Cards";
                    break;
            }

            FlashCards.Clear();
            foreach (var flashCard in flashCards)
            {
                FlashCards.Add(flashCard);
            }
        }

        public Command<FlashCard> NavigateToFlashCardEditorViewCommand { get; set; }
        private async Task NavigateToFlashCardEditorViewAsync(FlashCard? flashCard)
        {
            var navigationParams = new Dictionary<string, object>
            {
                { "FlashCardId", flashCard?.Id }
            };

            await _navigationService.GoToAsync(nameof(FlashCardEditerView), navigationParams);
        }
    }
}
