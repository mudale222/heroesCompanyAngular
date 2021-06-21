using System.ComponentModel.DataAnnotations;

namespace heroesCompany.dto {
    public class HeroDto {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsAttacker { get; set; }
        [Required]
        public string SuitColor { get; set; }
        public decimal StartingPower { get; set; }
    }
}
