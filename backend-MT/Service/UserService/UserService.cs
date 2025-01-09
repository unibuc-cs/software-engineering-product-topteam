using backend_MT.Models.DTOs.UserDTOs;
using backend_MT.Models;
using backend_MT.Service.UserService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.IdentityModel.Tokens;
using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Models.DTOs.UserDTOs;
using backend_MT.Models.Roles;
using backend_MT.Repositories;
using backend_MT.Services;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Web;
using static backend_MT.Models.Roles.Role;
using static System.Net.Mime.MediaTypeNames;
using backend_MT.Exceptions;

namespace backend_MT.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> RegisterAsync(RegisterDTO newUser)
        {
            var user = new User
            {
                UserName = newUser.username,
                Email = newUser.email,
                nume = newUser.nume,
                prenume = newUser.prenume,
                PhoneNumber = newUser.nrTelefon,
                pozaProfil = newUser.pozaProfil,
                nivel = newUser.nivel,
                profesorVerificat = newUser.profesorVerificat,
            };

            var result = await _userManager.CreateAsync(user, newUser.parola);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Elev.ToString());
            }

            return result;
        }

        public async Task<string> LoginAsync(LoginDTO login)
        {
            var user = await _userManager.FindByNameAsync(login.username);
            if (user == null)
            {
                throw new NotFoundException("Nu exista userul");
            }
            if (user.EmailConfirmed == false)
            {
                throw new NotFoundException("Emailul nu a fost confirmat, va rugam sa verificati emailul pentru link-ul de confirmare");
            }
            var result = await _signInManager.PasswordSignInAsync(login.username, login.parola, login.remember, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return TokenHandler(user, await _userManager.GetRolesAsync(user));
            }
            else if (result.IsLockedOut)
            {
                throw new LockedOutException("Prea multe incercari de logare in ultima perioada, contul este blocat.");
            }
            else
            {
                throw new WrongDetailsException("User sau parola gresita");
            }
        }
        public string TokenHandler(User user, IList<String> Role)
        {

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier , user.UserName),
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Name , user.nume),
                    new Claim(ClaimTypes.Email , user.Email),
                    new Claim(ClaimTypes.MobilePhone , user.PhoneNumber),
                    new Claim(ClaimTypes.Role,Role.FirstOrDefault(Roles.Elev.ToString()))
                };
            var token = new JwtSecurityToken(
                issuer: "https://localhost:7215/",
                audience: "https://localhost:7215/",
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                notBefore: DateTime.Now,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("rGSSVGNjKoM4qq41wHcssBm4JDzDxfc93rfcAy+id0I=")),
                SecurityAlgorithms.HmacSha256)
                );
            var x = new JwtSecurityTokenHandler().WriteToken(token);
            return x;
        }
    }
}
