using System;
using System.Collections.Generic;
using System.Text;

namespace FlipFlash.Models
{
    public class FlashCard
    {
        public enum DifficultyLevel
        {
            Easy,
            Normal,
            Medium,
            Hard,
            Unknown
        }
        public string Id { get; set; } = string.Empty;
        public CardContent Question { get; set; } = new CardContent();
        public CardContent Answer { get; set; } = new CardContent();
        public DateTime ExpirationDate { get; set; }
        public DifficultyLevel DiffLevel { get; set; } = DifficultyLevel.Unknown;
        public string CollectionId { get; set; } = string.Empty;

        public bool CanSaveFlashCard()
        {
            return !string.IsNullOrWhiteSpace(CollectionId) && !Question.isEmpty() && !Answer.isEmpty();
        }
    }
}
