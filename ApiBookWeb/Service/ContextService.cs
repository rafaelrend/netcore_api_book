using ApiBook.Lib.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBookWeb.Service
{
    public class ContextService
    {
        public static Context getContext(IConfiguration config, string connection_string_name = "default" )
        {
            string connectionString = config.GetConnectionString(connection_string_name);

            DbContextOptions<Context> options = new DbContextOptions<Context>();
            Context db = new Context(options, connectionString);

            return db;
        }
    }
}
