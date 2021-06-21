using Md_exercise.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heroesCompanyAngular.Models {
    public class ApplicationUser :  IdentityUser ,Ientity  {
        public new Guid Id { get; set; }
    }
}
