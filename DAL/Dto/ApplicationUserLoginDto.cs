using System.ComponentModel.DataAnnotations;

namespace heroesCompany.dto {
    public class ApplicationUserLoginDto {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
    }
}
