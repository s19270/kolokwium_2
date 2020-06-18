using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium_2.Controllers
{
    [Route("api/concert")]
    [ApiController]
    public class ConcertController : ControllerBase
    {
        private readonly ConcertDbContext _context;
        public ConcertController(ConcertDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult GetArtist(string id)
        {
            Zad1 z = new Zad1();
            z.Artist = _context.Artist.Where(a => a.IdArtist == int.Parse(id)).FirstOrDefault();
            if (z.Artist == null) return NotFound("Brak artysty o danym id");
            var help = _context.Artist_Event.Where(a => a.IdArtist == int.Parse(id));
            foreach (Artist_Event a in help)
            {
                var h = _context.Event.Where(e => e.IdEventr == a.IdEvent).FirstOrDefault();
                if (h == null) continue;
                if(!z.Events.Contains(h)) z.Events.Add(h);
            }
            z.Events = z.Events.OrderByDescending(e => e.StartDate).ToList();
            return Ok(z);
        }
        [HttpPut]
        public IActionResult UpdateEvent(Zad2 z)
        {
            var e = _context.Event.Where(h => h.IdEventr == z.idEvent).FirstOrDefault();
            if (e == null) return NotFound("Brak danego eventu");
            var r = _context.Artist.Where(h => h.IdArtist == z.idArtist).FirstOrDefault();
            if (r == null) return NotFound("Brak danego artysty");
            var a = _context.Artist_Event.Where(h => h.IdArtist == z.idArtist && h.IdEvent == z.idEvent).FirstOrDefault();
            if (a == null) return NotFound("Artysta nie wystepuje na podanym evencie");
            if (e.StartDate < DateTime.Now) return NotFound("Event sie juz zaczal");
            if (z.performaceDate < e.StartDate || z.performaceDate > e.EndDate) return NotFound("Nowy czas jest poza eventem");
            a.PerformanceDate = z.performaceDate;
            _context.SaveChanges();
            return Ok("Zmieniono date wystepu");
        }
    }
}