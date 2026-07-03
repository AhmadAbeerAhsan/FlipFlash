using System;
using System.Collections.Generic;
using System.Text;

namespace FlipFlash.Models
{
    public class CardContent
    {
        enum PrimaryContentType
        {
            IxText,
            IxImagePath,
            IxAudioPath
        }
        PrimaryContentType Primary {  get; set; }
        public string Text {  get; set; }
        public string ImagePath {  get; set; }
        public string AudioPath { get; set; }
    }
}
