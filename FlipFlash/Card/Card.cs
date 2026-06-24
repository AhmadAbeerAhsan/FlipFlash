using System;
using System.Collections.Generic;
using System.Text;

namespace FlipFlash.Card
{
    public class Card
    {
        public enum DifficultyLevel
        {
            Easy,
            Normal,
            Medium,
            Hard
        }
        string Id { get; set; }
        Content Question { get; set; }
        Content Answer { get; set; }
        public DateTime ExpirationDate { get; set; }
        DifficultyLevel DiffLevel { get; set; }
    }
}
