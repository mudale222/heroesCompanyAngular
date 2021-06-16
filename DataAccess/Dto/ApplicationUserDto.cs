using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace heroesCompanyAngular.dto {
    public class ApplicationUserDto {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string familyName { get; set; }
        [Required]
        public int age { get; set; }
    }
}
