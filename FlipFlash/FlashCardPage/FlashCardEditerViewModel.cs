
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
        private readonly IFlashCardService _flashCardService;
        private readonly ICardCollectionService _cardCollectionService;
        private readonly INavigationService _navigationService;

        public ObservableCollection<string> DifficultyLevels { get; set; } = [];
        public ObservableCollection<CardCollection> CardCollections { get; set; } = [];

        [ObservableProperty()]
        public FlashCard _flashCard = new FlashCard();

        [ObservableProperty()]
        public CardCollection _selectedCardCollection;

        [ObservableProperty()]
        public string _id;

        [ObservableProperty()]
        public string _title;
        public FlashCardEditerViewModel(IFlashCardService flashCardService, ICardCollectionService cardCollectionService, INavigationService navigationService)
        {
            _flashCardService = flashCardService;
            _cardCollectionService = cardCollectionService;
            _navigationService = navigationService;
        }

        public async Task InitializeAsync(string? flashCardId  = null)
        {
            List<string> difficultyLevels = new List<string>(
                Enum.GetNames(typeof(DifficultyLevel))
            );
            foreach (var difficultyLevel in difficultyLevels)
            {
                DifficultyLevels.Add(difficultyLevel);
            }

            var cardcollections = await _cardCollectionService.GetAsync();

            // Die Liste der Kartenkollektionen aktualisieren
            CardCollections.Clear();
            foreach (var collection in cardcollections)
            {
                CardCollections.Add(collection);
            }

            if (!string.IsNullOrEmpty(flashCardId))
            {
                var flashCard = await _flashCardService.GetByIdAsync(flashCardId);
                if (flashCard != null)
                {
                    FlashCard = flashCard;
                    SelectedCardCollection = CardCollections.FirstOrDefault(x => x.Id == flashCard.CollectionId);
                }
            }
            else
            {
                FlashCard = new FlashCard();
                SelectedCardCollection = CardCollections.FirstOrDefault();
            }
        }

        public async Task SaveFlashCardAsync()
        {
            FlashCard.CollectionId = SelectedCardCollection?.Id ?? string.Empty;

            if (FlashCard.CanSaveFlashCard())
            {
                await _flashCardService.SaveAsync(FlashCard);
                await _navigationService.GoToAsync("..");
            }
            else
            {
                return; //Output error message to user that the flashcard cannot be saved
            }
        }
}
}


