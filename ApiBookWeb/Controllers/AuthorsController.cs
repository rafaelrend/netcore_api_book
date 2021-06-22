using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBook.Lib.DAL;
using ApiBookWeb.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ApiBook.Lib.Models;

namespace ApiBookWeb.Controllers
{
    /*https://balta.io/blog/aspnetcore-3-autenticacao-autorizacao-bearer-jwt
     * https://docs.microsoft.com/pt-br/aspnet/core/mvc/models/model-binding?view=aspnetcore-3.1
     * dotnet restore
            dotnet add package Microsoft.AspNetCore.Authentication
            dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
     */
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {

        private readonly IConfiguration _config;

        public AuthorsController(IConfiguration config)
        {
            _config = config;
        }

        // GET: api/Authors
        [HttpGet]
        public object Get()
        {
            Context db = ContextService.getContext(this._config);
            var list = db.Authors.OrderBy(x => x.name).ToList();

            return new { data = list, total = list.Count };
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            Context db = ContextService.getContext(this._config);

            var reg = db.Authors.Find( id);

            if (reg == null)
            {

                return new { data = new Author(), error = 1, msg = "registro não encontrado" };
            }

            return new { data = reg, sucesso = 1 };
        }

        // POST: api/Authors
        [HttpPost]
        public object Post([FromForm] string name)
        {

            Context db = ContextService.getContext(this._config);
            Author entity = new Author();
            entity.name = name;
            entity.created_at = DateTime.Now;

            db.Authors.Add(entity);
            db.SaveChanges();

            return new { data = entity, sucesso = 1 };
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public object Put(int id, [FromForm] string name)
        {
            Context db = ContextService.getContext(this._config);
            Author entity = db.Authors.Find(id);
            entity.name = name;
            entity.updated_at = DateTime.Now;
            if ( entity.created_at == null)
            {
                entity.created_at = DateTime.Now;
            }

            db.SaveChanges();

            return new { data = entity, sucesso = 1 };
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            Context db = ContextService.getContext(this._config);
            Author entity = db.Authors.Find(id);
            if ( entity != null)
            {

                db.Authors.Remove(entity);
                return new { data = entity, sucesso = 1 };
            }
            else
            {

                return new { data = new Author(), error = 1, msg = "registro não encontrado" };
            }
        }
    }
}
