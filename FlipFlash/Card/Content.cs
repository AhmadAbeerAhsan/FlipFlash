using System;
using System.Collections.Generic;
using System.Text;

namespace FlipFlash.Card
{
    public class Content
    {
        enum PrimaryContentType
        {
            IxText,
            IxImagePath,
            IxAudioPath
        }
        PrimaryContentType Primary {  get; set; }
        string Text {  get; set; }
        string ImagePath {  get; set; }
        string AudioPath { get; set; }
    }
}
