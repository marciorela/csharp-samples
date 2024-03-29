using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAuth.Models;
using ApiAuth.Repositories;
using ApiAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);
            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            // GERA O TOKEN
            var token = TokenService.GenerateToken(user);

            // OCULTA A SENHA
            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }
        
    }
}