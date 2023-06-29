using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCoreClientEgitim.Data
{
    public class Kurslar
    {
        [Key]

        public int KursId { get; set; }
        public string KursAdi { get; set; }
        public string KursAciklama { get; set; }
        public int KursSuresi { get; set; }
        public int KursUcreti { get; set; }

        [ForeignKey("Egitmenler")]
        public int EgitimenId { get; set; }

        public Egitmenler Egitmenler { get; set; }

    }
}
