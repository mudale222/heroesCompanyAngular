using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heroesCompanyAngular.Models.ResponseModels {
    public class PowerUpdateResponse {
        public bool isTrainSuccess { get; set; }
        public decimal updatedPower { get; set; }
    }
}
