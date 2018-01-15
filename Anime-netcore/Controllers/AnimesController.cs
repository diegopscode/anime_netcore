using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Animenetcore.Models;

namespace Anime_netcore.Controllers
{
    [Route("api/[controller]")]
    public class AnimesController : Controller
    {
        private readonly AnimeContext DB;

        public AnimesController(AnimeContext context) {
            DB = new AnimeContext(context);
        }

        // GET api/animes
        [HttpGet]
        public IEnumerable<Anime> Get()
        {
            //Anime anime = new Anime();

            //return anime.Index();

            return DB.Animes.ToList();
        }

        // GET api/animes/5
        [HttpGet("{id}")]
        public Anime Get(int id)
        {
            Anime anime = new Anime();

            return anime.Index().Where(x => x.id == id).FirstOrDefault();
        }

        // POST api/animes
        [HttpPost]
        public Anime Post([FromBody]Anime anime)
        {
            return anime.Store(anime);
        }

        // PUT api/animes/5
        [HttpPut("{id}")]
        public Anime Put(int id, [FromBody]Anime anime)
        {
            return anime.Update(id, anime);
        }

        // DELETE api/animes/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Anime _anime = new Anime();

            return _anime.Destroy(id);
        }
    }
}
