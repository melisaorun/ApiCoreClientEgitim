using System.ComponentModel.DataAnnotations;

namespace ApiCoreClientEgitim.Data
{
    public class Egitmenler
    {
        [Key]
        public int EgitmenId { get; set; }
        public string AdiSoyadi { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
    }
}
