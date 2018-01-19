using System;
using System.Collections.Generic;

namespace Animenetcore.Models
{
    public class Episode
    {
        public int id { get; set; }
        public int episode { get; set; }
        public string name { get; set; }

        public Anime anime { get; set; }

    }
}
