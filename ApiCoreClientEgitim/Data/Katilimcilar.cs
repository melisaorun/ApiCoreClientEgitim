using System.ComponentModel.DataAnnotations;

namespace ApiCoreClientEgitim.Data
{
    public class Katilimcilar
    {
        [Key]
        public int KatilimciId { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

    }
}
