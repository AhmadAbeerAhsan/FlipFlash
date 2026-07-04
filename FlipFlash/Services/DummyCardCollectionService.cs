using FlipFlash.Models;
using FlipFlash.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlipFlash.Services
{
    public class DummyCardCollectionService : ICardCollectionService
    {
        private readonly List<CardCollection> _collections = new()
        {
            new CardCollection
            {
                Id        = "col-001",
                Name      = "General Knowledge",
                ImagePath = "images/collections/general_knowledge.png",
                CardsList = new List<string> { "fc-001", "fc-002" }
            },
            new CardCollection
            {
                Id        = "col-002",
                Name      = "Computer Science",
                ImagePath = "images/collections/computer_science.png",
                CardsList = new List<string> { "fc-003", "fc-004" }
            },
            new CardCollection
            {
                Id        = "col-003",
                Name      = "Science & History",
                ImagePath = "images/collections/science_history.png",
                CardsList = new List<string> { "fc-005", "fc-006" }
            },
        };

        private readonly IFlashCardService _flashCardService;

        public DummyCardCollectionService(IFlashCardService flashCardService)
        {
            _flashCardService = flashCardService;
        }

        public Task<IEnumerable<CardCollection>> GetAsync()
        {
            return Task.FromResult<IEnumerable<CardCollection>>(_collections);
        }
        public async Task<IEnumerable<CardCollectionWithFlashCardCount>> GetWithFlashCardCountAsync()
        {
            List<CardCollectionWithFlashCardCount> collectionsWithCount = new();
            foreach (var collection in _collections)
            {
                var cards = await _flashCardService.GetByLocationAsync(collection.Id);
                collectionsWithCount.Add(new CardCollectionWithFlashCardCount
                {
                    Id = collection.Id,
                    Name = collection.Name,
                    ImagePath = collection.ImagePath,
                    CardsList = collection.CardsList,
                    FlashCardCount = cards.Count()
                });
            }
            return collectionsWithCount;
        }
        public Task<CardCollection?> GetByIdAsync(string id)
        {
            var collection = _collections.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(collection);
        }
        public Task SaveAsync(CardCollection cardCollection)
        {
            var existing = _collections.FindIndex(c => c.Id == cardCollection.Id);
            if (existing >= 0)
                _collections[existing] = cardCollection;
            else
                _collections.Add(cardCollection);

            return Task.CompletedTask;
        }
        public Task DeleteAsync(CardCollection cardCollection)
        {
            _collections.RemoveAll(c => c.Id == cardCollection.Id);
            return Task.CompletedTask;
        }

        public Task DeleteAllAsync()
        {
            _collections.Clear();
            return Task.CompletedTask;
        }
    }
}
