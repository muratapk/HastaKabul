using System.ComponentModel.DataAnnotations;

namespace HastaKabul.Models
{
    public class Hastalar
    {
        [Key]
        public int HastaId { get; set; }
        public int HastaTc { get; set; }
        public string  HastaAd { get; set; }
        public int HastaYas { get; set; }
        public string HastaEmail { get; set; }  
        public string HastaPassword { get; set; }
        
    }
}
