using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace heroesCompanyAngular.dto {
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
