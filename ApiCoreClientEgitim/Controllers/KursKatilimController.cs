using ApiCoreClientEgitim.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiCoreClientEgitim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KursKatilimController : ControllerBase
    {

        private readonly ApplicationDbContext _db;
        public KursKatilimController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetSpr()
        {
            return Ok(_db.KursKatilim.ToList());
        }

        [HttpPost]
        public IActionResult AddSpr(KursKatilim kurskatilim)
        {
            _db.Add(kurskatilim);
            _db.SaveChanges();
            return Created("", kurskatilim);

        }
        [HttpGet("{id}")]
        public IActionResult GetSprById(int id)
        {
            return Ok(_db.KursKatilim.FirstOrDefault(x => x.KursKatilimId == id));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSpr(int id)
        {
            var delete = _db.KursKatilim.FirstOrDefault(x => x.KursKatilimId == id);
            _db.Remove(delete);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSpr(KursKatilim kurskatilim, int id)
        {
            var update = _db.KursKatilim.FirstOrDefault(x => x.KursKatilimId == id);
            update.BaslangicTarihi = kurskatilim.BaslangicTarihi;
            update.BitisTarihi = kurskatilim.BitisTarihi;
           
            _db.SaveChanges();
            return NoContent();

        }
    }
}
