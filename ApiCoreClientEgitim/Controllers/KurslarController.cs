using ApiCoreClientEgitim.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiCoreClientEgitim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KurslarController : ControllerBase
    {
            private readonly ApplicationDbContext _db;
            public KurslarController(ApplicationDbContext db)
            {
                _db = db;
            }

            [HttpGet]
            public IActionResult GetSpr()
            {
                return Ok(_db.Kurslar.ToList());
            }

            [HttpPost]
            public IActionResult AddSpr(Kurslar kurslar)
            {
                _db.Add(kurslar);
                _db.SaveChanges();
                return Created("", kurslar);

            }
            [HttpGet("{id}")]
            public IActionResult GetSprById(int id)
            {
                return Ok(_db.Kurslar.FirstOrDefault(x => x.KursId == id));
            }
            [HttpDelete("{id}")]
            public IActionResult DeleteSpr(int id)
            {
                var delete = _db.Kurslar.FirstOrDefault(x => x.KursId == id);
                _db.Remove(delete);
                _db.SaveChanges();
                return NoContent();
            }

            [HttpPut("{id}")]
            public IActionResult UpdateSpr(Kurslar kurslar, int id)
            {
                var update = _db.Kurslar.FirstOrDefault(x => x.KursId == id);
                update.KursAdi = kurslar.KursAdi;
                update.KursAciklama = kurslar.KursAciklama;
                update.KursSuresi = kurslar.KursSuresi;
                update.KursUcreti= kurslar.KursUcreti;
                _db.SaveChanges();
                return NoContent();

            }
      
    }
}
