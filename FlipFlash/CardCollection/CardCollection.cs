using System;
using System.Collections.Generic;
using System.Text;

namespace FlipFlash.CardCollection
{
    public class CardCollection
    {
        public string Id {  get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<string> CardsList { get; set; } 
    }
}
