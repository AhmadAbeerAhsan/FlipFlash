using System;
using System.Collections.Generic;
using System.Text;

namespace FlipFlash.FlashCard
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
        public Content Question { get; set; }
        public Content Answer { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DifficultyLevel DiffLevel { get; set; }
        public string CollectionId { get; set; }
    }
}
