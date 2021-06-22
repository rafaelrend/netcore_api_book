using System;
using System.Collections.Generic;
using System.Text;
using ApiBook.Lib.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace ApiBook.Lib.DAL
{
    public class Context : DbContext
    {
        private string _connectionString;
        public Context(DbContextOptions<Context> options, string connectionString) : base(options) {
            this._connectionString = connectionString;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            //action => action.CommandTimeout( 600)
            optionsBuilder.UseMySql(this._connectionString,
                       options => options.CharSet(Pomelo.EntityFrameworkCore.MySql.Storage.CharSet.Utf8Mb4).CommandTimeout(600)
                       );

            //optionsBuilder.UseMySQL("server=rafaeldatabase;port=3305;user=root;password=;database=rend_api_book" );
           // optionsBuilder.UseS
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
