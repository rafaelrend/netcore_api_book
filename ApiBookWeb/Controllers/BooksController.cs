using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ApiBook.Lib.Models;
using ApiBook.Lib.DAL;
using ApiBookWeb.Service;

namespace ApiBookWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IConfiguration _config;

        public BooksController(IConfiguration config)
        {
            _config = config;
        }

        // GET: api/Books
        [HttpGet]
        public object Get([FromQuery] string filtro, [FromQuery] string order, 
                 [FromQuery] string order_type)
        {


            if (filtro != null && filtro != ""){
                         //	$str_filt = str_replace("'", "''", $request->input("filtro"));
                       // 	$filtro.= " and ( b.title like '%".$str_filt."%' or b.isbn like '%".$str_filt."%' or a.name like '%".$str_filt."%'  ) ";
            }
            if ( order == null || order == String.Empty)
            {
                order = "id";
                if (order_type == null || order_type == String.Empty)
                {
                    order_type = "desc";
                }
            }
           
             string sql = @"select b.*, a.name as author_name from book b
                                    left join author a on a.id = b.author_id
                                    where 1 = 1 " + filtro + 
                                 " order by "+ order +  " " + order_type;


            using (var db = ContextService.getContext(this._config))
            {
             //   var list = db.Books.FromSQL
            }

             //  db.Query <>

          //  var list = from book in db.Books
            //           join auth in db.Authors on auth.id equals book.id
              //         select new { book, auth.name }



            return new string[] { "value1", "value2" };
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public object Get(int id)
        {

            Context db = ContextService.getContext(this._config);
            var entity = db.Books.Find(id);
            entity.configureOut();

            return new { data = entity, sucesso = 1 };
        }

        // POST: api/Books
        [HttpPost]
        public object Post([FromForm] Book entity)
        {
            Context db = ContextService.getContext(this._config);
           
            entity.created_at = DateTime.Now;
            entity.configureIn();

            db.Books.Add(entity);
            db.SaveChanges();


            return new { data = entity, sucesso = 1 };

        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            Context db = ContextService.getContext(this._config);
            Book entity = db.Books.Find(id);
            if (entity != null)
            {

                db.Books.Remove(entity);
                return new { data = entity, sucesso = 1 };
            }
            else
            {

                return new { data = new Book(), error = 1, msg = "registro não encontrado" };
            }
        }
    }
}
