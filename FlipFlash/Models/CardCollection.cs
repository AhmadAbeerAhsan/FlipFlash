using System;
using System.Collections.Generic;
using System.Text;

namespace FlipFlash.Models
{
    public class CardCollection
    {
        public string Id {  get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public List<string> CardsList { get; set; }  = new List<string>();
    }
}
