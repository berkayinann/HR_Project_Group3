using HR_Project_Group3_App.DTOs.AppUserDTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project_Group3_App.Services
{
    public interface IAppUserService
    {
        Task<IdentityResult> Register(RegisterDTO model);

        Task<SignInResult> Login(LoginDTO model);

        Task<int> GetIDByRole(string appuserId, string roleName);

        Task<string> SendRenewPasswordCode(string email);

    }
}
