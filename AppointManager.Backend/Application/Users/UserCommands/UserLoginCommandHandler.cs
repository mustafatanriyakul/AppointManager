using AppointManager.Backend.Domain.Entities.Users;
using AppointManager.Backend.Infrastructure.Interfaces;
using AppointManager.Backend.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AppointManager.Backend.Application.Users.UserCommands
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, string>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly ITokenService _tokenService;

        public UserLoginCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(UserLoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);

            if (user == null)
            {
                throw new Exception("HATA: Kayıtlı böyle bir kullanıcı yok.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(
                user,
                command.Password,
                lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new Exception("HATA: Geçersiz e-posta veya şifre.");
            }

            var roles = await _userManager.GetRolesAsync(user);

            if (!roles.Contains(command.RequestedRole)){
                throw new Exception($"HATA: Kullanıcı bu role {command.RequestedRole} sahip değil");
            }

            var token = _tokenService.CreateToken(user, roles);

            return token;
        }

    }
}
