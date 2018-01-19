using System;
using System.Collections.Generic;

namespace Animenetcore.Models
{
    public class Anime
    {
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }

        public List<Episode> episodes { get; set; } = new List<Episode>();

        public Anime()
        {
        }

        public Anime(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

    }
}
