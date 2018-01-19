using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Animenetcore.Models;

namespace Animenetcore.Controllers
{
    [Route("api/[controller]")]
    public class AnimesController : Controller
    {
        private readonly AnimeContext _context;

        public AnimesController(AnimeContext context) {
            _context = context;
        }

        // GET api/animes
        [HttpGet]
        public IEnumerable<Anime> Get()
        {
            return _context.Animes.ToList();
        }

        // GET api/animes/5
        [HttpGet("{id}")]
        public Anime Get(int id)
        {
            return _context.Animes.Find(id);
        }

        // POST api/animes
        [HttpPost]
        public Anime Post([FromBody]Anime anime)
        {
            _context.Add<Anime>(anime);
            _context.SaveChanges();

            return anime;
        }

        // PUT api/animes/5
        [HttpPut("{id}")]
        public Anime Put(int id, [FromBody]Anime anime)
        {
            _context.Animes.Update(anime);
            _context.SaveChanges();

            return anime;
        }

        // DELETE api/animes/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            _context.Remove(_context.Animes.Single(a => a.id == id));
            _context.SaveChanges();

            return true;
        }
    }
}
