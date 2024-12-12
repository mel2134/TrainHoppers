using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainHoppers.Core.Domain;
using TrainHoppers.Core.Dto;
using TrainHoppers.Core.Dto.AccountsDtos;
using TrainHoppers.Core.ServiceInterface;

namespace TrainHoppers.ApplicationServices.Services
{
    public class AccountsServices : IAccountsServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailsServices _emailsServices;
        public AccountsServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailsServices emailsServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailsServices = emailsServices;
        }
        public async Task<ApplicationUser> Register(ApplicationUserDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                City = dto.City,
                PlayerProfileID = dto.AssociatedPlayerProfile = await _playerprofileServices.Create();
            };
            var result = await _userManager.CreateAsync(user,dto.Password);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                _emailsServices.SendEmailToken(new EmailTokenDto(),token);
            }
            return user;
        }
        public async Task<ApplicationUser> ConfirmEmail(string userId,string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                string errorMsg = $"User with id {userId} does not exist";
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return user;
        }
        public async Task<ApplicationUser> Login(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            return user;
        }
    }
}
