using heroesCompanyAngular.dto;
using heroesCompanyAngular.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heroesCompanyAngular.ControllersServices {
    public interface IAccount {
        Task<Response> Create(ApplicationUserDto registrtionData);
    }
}
