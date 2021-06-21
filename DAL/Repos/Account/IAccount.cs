using heroesCompany.dto;
using heroesCompany.Models;
using System.Threading.Tasks;

namespace heroesCompany.ControllersServices {
    public interface IAccount {
        Task<Response> Create(ApplicationUserDto registrtionData);
    }
}
