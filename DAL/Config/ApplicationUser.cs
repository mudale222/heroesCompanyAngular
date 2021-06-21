using heroesCompany.Models.HelperModels;
using Microsoft.AspNetCore.Identity;
using System;

namespace heroesCompany.Models {
    public class ApplicationUser : IdentityUser, Ientity {
        public new Guid Id { get; set; }
    }
}
