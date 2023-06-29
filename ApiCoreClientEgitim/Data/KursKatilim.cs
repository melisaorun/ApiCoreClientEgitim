using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCoreClientEgitim.Data
{
    public class KursKatilim
    {
        [Key]
        public int KursKatilimId { get; set; }
        public string BaslangicTarihi { get; set; }
        public string BitisTarihi { get; set; }

        [ForeignKey("Kurslar")]
        public int KursId { get; set; }

        public Kurslar Kurslar { get; set; }

        [ForeignKey("Katilimcilar")]
        public int KatilimciId { get; set; }

        public Katilimcilar Katilimcilar { get; set; }
    }
}
