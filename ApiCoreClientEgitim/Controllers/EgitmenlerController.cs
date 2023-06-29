using ApiCoreClientEgitim.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiCoreClientEgitim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EgitmenlerController : ControllerBase
    {

        private readonly ApplicationDbContext _db;
        public EgitmenlerController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetSpr()
        {
            return Ok(_db.Egitmenler.ToList());
        }

        [HttpPost]
        public IActionResult AddSpr(Egitmenler egitmenler)
        {
            _db.Add(egitmenler);
            _db.SaveChanges();
            return Created("", egitmenler);

        }
        [HttpGet("{id}")]
        public IActionResult GetSprById(int id)
        {
            return Ok(_db.Egitmenler.FirstOrDefault(x => x.EgitmenId == id));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSpr(int id)
        {
            var delete = _db.Egitmenler.FirstOrDefault(x => x.EgitmenId == id);
            _db.Remove(delete);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSpr(Egitmenler egitmenler, int id)
        {
            var update = _db.Egitmenler.FirstOrDefault(x => x.EgitmenId == id);
            update.AdiSoyadi = egitmenler.AdiSoyadi;
            update.Telefon = egitmenler.Telefon;
            update.Email = egitmenler.Email;
           
            _db.SaveChanges();
            return NoContent();

        }
    }
}
