using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiBook.Lib.Models;
using ApiBook.Lib.DAL;
using ApiBook.Lib.Repositories;
using Microsoft.Extensions.Configuration;
using ApiBookWeb.Service;

namespace ApiBookWeb.Controllers
{
    //https://github.com/andrebaltieri/aspnetcore3-efcore3-jwt-roles/blob/master/Controllers/HomeController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromForm]User model)
        {
            Context db = ContextService.getContext(this._config);
            UserRepository repo = new UserRepository(db);

            var user = repo.GetByEmailPass(model.email, model.password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            string api_token = TokenService.GenerateToken(this._config, user);

            return new
            {
                id = user.id,
                token = api_token,
                name = user.name,
                email = user.email
            };
        }
    }
}