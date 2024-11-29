using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainHoppers.Core.Domain;
using TrainHoppers.Core.Dto.AccountsDtos;

namespace TrainHoppers.Core.ServiceInterface
{
    public interface IAccountsServices
    {
        Task<ApplicationUser> Register(ApplicationUserDto dto);
        Task<ApplicationUser> ConfirmEmail(string userId, string token);
        Task<ApplicationUser> Login(LoginDto dto);
    }
}
