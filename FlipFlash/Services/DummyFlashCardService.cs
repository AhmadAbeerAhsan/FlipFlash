using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace FlipFlash.Services
{
    public class DummyFlashCardService : IFlashCardService
    {
        private readonly List<FlashCard.FlashCard> _cards = new()
        {
            new FlashCard.FlashCard
            {
                Id = "fc-001",
                Question = new FlashCard.Content { Text = "What is the capital of France?" },
                Answer   = new FlashCard.Content { Text = "Paris" },
                ExpirationDate = DateTime.Today.AddDays(10),
                DiffLevel = FlashCard.FlashCard.DifficultyLevel.Easy,
                CollectionId = "col-001"
            },
            new FlashCard.FlashCard
            {
                Id = "fc-002",
                Question = new FlashCard.Content { Text = "What does CPU stand for?" },
                Answer   = new FlashCard.Content { Text = "Central Processing Unit" },
                ExpirationDate = DateTime.Today.AddDays(3),
                DiffLevel = FlashCard.FlashCard.DifficultyLevel.Normal,
                CollectionId = "col-001"
            },
            new FlashCard.FlashCard
            {
                Id = "fc-003",
                Question = new FlashCard.Content { Text = "What is the time complexity of binary search?" },
                Answer   = new FlashCard.Content { Text = "O(log n)" },
                ExpirationDate = DateTime.Today,
                DiffLevel = FlashCard.FlashCard.DifficultyLevel.Medium,
                CollectionId = "col-002"
            },
            new FlashCard.FlashCard
            {
                Id = "fc-004",
                Question = new FlashCard.Content { Text = "Explain the difference between a stack and a queue." },
                Answer   = new FlashCard.Content { Text = "A stack is LIFO (Last In First Out); a queue is FIFO (First In First Out)." },
                ExpirationDate = DateTime.Today.AddDays(-2),
                DiffLevel = FlashCard.FlashCard.DifficultyLevel.Hard,
                CollectionId = "col-002"
            },
            new FlashCard.FlashCard
            {
                Id = "fc-005",
                Question = new FlashCard.Content { Text = "What is Newton's second law of motion?" },
                Answer   = new FlashCard.Content { Text = "F = m × a (Force equals mass times acceleration)" },
                ExpirationDate = DateTime.Today.AddDays(4),
                DiffLevel = FlashCard.FlashCard.DifficultyLevel.Normal,
                CollectionId = "col-003"
            },
            new FlashCard.FlashCard
            {
                Id = "fc-006",
                Question = new FlashCard.Content { Text = "What year did World War II end?" },
                Answer   = new FlashCard.Content { Text = "1945" },
                ExpirationDate = DateTime.Today.AddDays(-5),
                DiffLevel = FlashCard.FlashCard.DifficultyLevel.Easy,
                CollectionId = "col-003"
            },
        };

        public Task<IEnumerable<FlashCard.FlashCard>> GetAsync()
        {
            return Task.FromResult<IEnumerable<FlashCard.FlashCard>>(_cards);
        }

        public Task<FlashCard.FlashCard?> GetByIdAsync(string id)
        {
            var card = _cards.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(card);
        }

        public Task SaveAsync(FlashCard.FlashCard card)
        {
            var existing = _cards.FindIndex(c => c.Id == card.Id);
            if (existing >= 0)
                _cards[existing] = card;
            else
                _cards.Add(card);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(FlashCard.FlashCard card)
        {
            _cards.RemoveAll(c => c.Id == card.Id);
            return Task.CompletedTask;
        }

        public Task DeleteAllAsync()
        {
            _cards.Clear();
            return Task.CompletedTask;
        }

        public Task<IEnumerable<FlashCard.FlashCard>> GetByLocationAsync(string collectionId)
        {
            var result = _cards.Where(c => c.CollectionId == collectionId);
            return Task.FromResult<IEnumerable<FlashCard.FlashCard>>(result);
        }

        public Task<IEnumerable<FlashCard.FlashCard>> GetExpiredAsync()
        {
            var result = _cards.Where(c => c.ExpirationDate < DateTime.Today);
            return Task.FromResult<IEnumerable<FlashCard.FlashCard>>(result);
        }

        public Task<IEnumerable<FlashCard.FlashCard>> GetExpiresTodayAsync()
        {
            var result = _cards.Where(c => c.ExpirationDate.Date == DateTime.Today);
            return Task.FromResult<IEnumerable<FlashCard.FlashCard>>(result);
        }

        public Task<IEnumerable<FlashCard.FlashCard>> GetExpiresSoonAsync(int days = 5)
        {
            var cutoff = DateTime.Today.AddDays(days);
            var result = _cards.Where(c => c.ExpirationDate.Date >= DateTime.Today
                                        && c.ExpirationDate.Date <= cutoff);
            return Task.FromResult<IEnumerable<FlashCard.FlashCard>>(result);
        }
    }
}
