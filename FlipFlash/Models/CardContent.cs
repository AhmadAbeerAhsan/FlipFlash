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
        public string Text {  get; set; } = string.Empty;
        public string ImagePath {  get; set; } = string.Empty;
        public string AudioPath { get; set; } = string.Empty;

        public bool isEmpty()
        {
            return string.IsNullOrWhiteSpace(Text) && string.IsNullOrWhiteSpace(ImagePath) && string.IsNullOrWhiteSpace(AudioPath);
        }
    }
}
