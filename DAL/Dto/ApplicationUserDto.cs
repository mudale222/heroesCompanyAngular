using System.ComponentModel.DataAnnotations;


namespace heroesCompany.dto {
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
