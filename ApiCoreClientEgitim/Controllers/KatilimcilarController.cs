using ApiCoreClientEgitim.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiCoreClientEgitim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KatilimcilarController : ControllerBase
    {

        private readonly ApplicationDbContext _db;
        public KatilimcilarController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetSpr()
        {
            return Ok(_db.Katilimcilar.ToList());
        }

        [HttpPost]
        public IActionResult AddSpr(Katilimcilar katilimcilar)
        {
            _db.Add(katilimcilar);
            _db.SaveChanges();
            return Created("", katilimcilar);

        }
        [HttpGet("{id}")]
        public IActionResult GetSprById(int id)
        {
            return Ok(_db.Katilimcilar.FirstOrDefault(x => x.KatilimciId == id));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSpr(int id)
        {
            var delete = _db.Katilimcilar.FirstOrDefault(x => x.KatilimciId == id);
            _db.Remove(delete);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSpr(Katilimcilar katilimcilar, int id)
        {
            var update = _db.Katilimcilar.FirstOrDefault(x => x.KatilimciId == id);
            update.AdSoyad = katilimcilar.AdSoyad;
            update.Telefon = katilimcilar.Telefon;
            update.Email = katilimcilar.Email; 
            
            _db.SaveChanges();
            return NoContent();

        }
    }
}
