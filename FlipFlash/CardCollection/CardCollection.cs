using System;
using System.Collections.Generic;
using System.Text;

namespace FlipFlash.CardCollection
{
    public class CardCollection
    {
        string Id {  get; set; }
        string Name { get; set; }
        string ImagePath { get; set; }
        List<string> CardsList { get; set; } 
    }
}
