using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Animenetcore.Models
{
    public class Anime
    {
        public int id { get; set; }
        public string name { get; set; }
        public int episodes { get; set; }
        public int year { get; set; }

        //public List<Anime> allAnimes;

        public Anime()
        {
            //allAnimes = this.Index();
        }

        public Anime(int id, string name, int episodes)
        {
            this.id = id;
            this.name = name;
            this.episodes = episodes;

            //allAnimes = this.Index();
        }

        public List<Anime> Index()
        {
            var pathData = @"Data/anime.json";

            var json = File.ReadAllText(pathData);

            List<Anime> listAnimes = JsonConvert.DeserializeObject<List<Anime>>(json);

            return listAnimes;
        }

        public bool OverrideAnimes(List<Anime> listAnimes)
        {
            var pathData = @"Data/anime.json";

            var json = JsonConvert.SerializeObject(listAnimes, Formatting.Indented);
            File.WriteAllText(pathData, json);

            return true;
        }

        public Anime Store(Anime anime)
        {

            var allAnimes = this.Index();

            var maxId = allAnimes.Count;
            anime.id = maxId + 1;

            allAnimes.Add(anime);

            this.OverrideAnimes(allAnimes);

            return anime;
        }

        public Anime Update(int id, Anime anime)
        {
            var allAnimes = this.Index();

            var animeIndex = allAnimes.FindIndex(a => a.id == anime.id);

            if (animeIndex >= 0)
            {
                anime.id = id;
                allAnimes[animeIndex] = anime;
            }
            else
            {
                return null;
            }

            this.OverrideAnimes(allAnimes);

            return anime;
        }

        public bool Destroy(int id)
        {
            var allAnimes = this.Index();

            var animeIndex = allAnimes.FindIndex(a => a.id == id);

            if (animeIndex >= 0)
            {
                allAnimes.RemoveAt(animeIndex);
            }
            else
            {
                return false;
            }

            this.OverrideAnimes(allAnimes);

            return true;
        }
    }
}
