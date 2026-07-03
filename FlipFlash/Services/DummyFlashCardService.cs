using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace FlipFlash.Services
{
    public class DummyFlashCardService : IFlashCardService
    {
        private readonly List<Models.FlashCard> _cards = new()
        {
            new Models.FlashCard
            {
                Id = "fc-001",
                Question = new Models.CardContent { Text = "What is the capital of France?" },
                Answer   = new Models.CardContent { Text = "Paris" },
                ExpirationDate = DateTime.Today.AddDays(10),
                DiffLevel = Models.FlashCard.DifficultyLevel.Easy,
                CollectionId = "col-001"
            },
            new Models.FlashCard
            {
                Id = "fc-002",
                Question = new Models.CardContent { Text = "What does CPU stand for?" },
                Answer   = new Models.CardContent { Text = "Central Processing Unit" },
                ExpirationDate = DateTime.Today.AddDays(3),
                DiffLevel = Models.FlashCard.DifficultyLevel.Normal,
                CollectionId = "col-001"
            },
            new Models.FlashCard
            {
                Id = "fc-003",
                Question = new Models.CardContent { Text = "What is the time complexity of binary search?" },
                Answer   = new Models.CardContent { Text = "O(log n)" },
                ExpirationDate = DateTime.Today,
                DiffLevel = Models.FlashCard.DifficultyLevel.Medium,
                CollectionId = "col-002"
            },
            new Models.FlashCard
            {
                Id = "fc-004",
                Question = new Models.CardContent { Text = "Explain the difference between a stack and a queue." },
                Answer   = new Models.CardContent { Text = "A stack is LIFO (Last In First Out); a queue is FIFO (First In First Out)." },
                ExpirationDate = DateTime.Today.AddDays(-2),
                DiffLevel = Models.FlashCard.DifficultyLevel.Hard,
                CollectionId = "col-002"
            },
            new Models.FlashCard
            {
                Id = "fc-005",
                Question = new Models.CardContent { Text = "What is Newton's second law of motion?" },
                Answer   = new Models.CardContent { Text = "F = m × a (Force equals mass times acceleration)" },
                ExpirationDate = DateTime.Today.AddDays(4),
                DiffLevel = Models.FlashCard.DifficultyLevel.Normal,
                CollectionId = "col-003"
            },
            new Models.FlashCard
            {
                Id = "fc-006",
                Question = new Models.CardContent { Text = "What year did World War II end?" },
                Answer   = new Models.CardContent { Text = "1945" },
                ExpirationDate = DateTime.Today.AddDays(-5),
                DiffLevel = Models.FlashCard.DifficultyLevel.Easy,
                CollectionId = "col-003"
            },
        };

        public Task<IEnumerable<Models.FlashCard>> GetAsync()
        {
            return Task.FromResult<IEnumerable<Models.FlashCard>>(_cards);
        }

        public Task<Models.FlashCard?> GetByIdAsync(string id)
        {
            var card = _cards.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(card);
        }

        public Task SaveAsync(Models.FlashCard card)
        {
            var existing = _cards.FindIndex(c => c.Id == card.Id);
            if (existing >= 0)
                _cards[existing] = card;
            else
                _cards.Add(card);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(Models.FlashCard card)
        {
            _cards.RemoveAll(c => c.Id == card.Id);
            return Task.CompletedTask;
        }

        public Task DeleteAllAsync()
        {
            _cards.Clear();
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Models.FlashCard>> GetByLocationAsync(string collectionId)
        {
            var result = _cards.Where(c => c.CollectionId == collectionId);
            return Task.FromResult<IEnumerable<Models.FlashCard>>(result);
        }

        public Task<IEnumerable<Models.FlashCard>> GetExpiredAsync()
        {
            var result = _cards.Where(c => c.ExpirationDate < DateTime.Today);
            return Task.FromResult<IEnumerable<Models.FlashCard>>(result);
        }

        public Task<IEnumerable<Models.FlashCard>> GetExpiresTodayAsync()
        {
            var result = _cards.Where(c => c.ExpirationDate.Date == DateTime.Today);
            return Task.FromResult<IEnumerable<Models.FlashCard>>(result);
        }

        public Task<IEnumerable<Models.FlashCard>> GetExpiresSoonAsync(int days = 5)
        {
            var cutoff = DateTime.Today.AddDays(days);
            var result = _cards.Where(c => c.ExpirationDate.Date >= DateTime.Today
                                        && c.ExpirationDate.Date <= cutoff);
            return Task.FromResult<IEnumerable<Models.FlashCard>>(result);
        }
    }
}
