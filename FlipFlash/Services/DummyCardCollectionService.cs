using FlipFlash.Models;
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

        public Task<IEnumerable<CardCollection>> GetAsync()
        {
            return Task.FromResult<IEnumerable<CardCollection>>(_collections);
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
