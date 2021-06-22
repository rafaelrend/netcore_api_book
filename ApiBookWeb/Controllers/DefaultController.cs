using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiBook.Lib.DAL;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using ApiBookWeb.Service;

using Microsoft.Extensions.Configuration;

namespace ApiBookWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        private readonly IConfiguration _config;

        public DefaultController(IConfiguration config)
        {
            _config = config;
        }
        // GET: api/Default
        [HttpGet]
        public object Get()
        {

            Context db = ContextService.getContext(this._config); 
            var list = db.Authors.ToList();

            return new { data = list, total = list.Count };
        }

        // GET: api/Default/5
        [HttpGet("{id}")] //, Name = "Get"
        public object Get(int id)
        {
            Context db = ContextService.getContext(this._config);

            var reg = db.Authors.Find(id.ToString().Split(',') );

            if ( reg == null)
            {

                return new { data = new List<string>() , error = 1 , msg = "registro não encontrado" };
            }

            return new { data = reg, sucesso = 1 };
            
        }

        // POST: api/Default
        [HttpPost]
        public void Post([FromBody] string value)
        {
            /*
                $reg->title = $request->input('title');  
                $reg->description = $request->input('description');  
                $reg->isbn = $request->input('isbn');  
                $reg->stock = $request->input('stock');  
                $reg->author_id = $request->input('author_id');  
                
                $price_txt = $request->input('price_txt');
                $reg->price = \App\Http\Dao\ConfigDao::numeroBanco($price_txt); // $request->input('price');  
                $reg->editor = $request->input('editor');  
                
                
                $reg->date_release = \App\Http\Dao\ConfigDao::dataBanco($request->input('date_release_txt'). " ". $request->input('date_release_hour_txt')); //$request->input('date_release');  


           */

        }

        // PUT: api/Default/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
