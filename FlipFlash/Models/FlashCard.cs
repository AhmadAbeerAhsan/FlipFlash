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
            Hard
        }
        public string Id { get; set; }
        public CardContent Question { get; set; }
        public CardContent Answer { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DifficultyLevel DiffLevel { get; set; }
        public string CollectionId { get; set; }
    }
}
