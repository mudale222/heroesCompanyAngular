using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heroesCompanyAngular.Models.ResponseModels {
    public class DeleteHeroResponse {
        public bool isDeleted { get; set; }
        public string reason { get; set; }
    }
}
