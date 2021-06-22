using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ApiBook.Lib.Models;
using ApiBook.Lib.DAL;
using System.Linq;

namespace ApiBook.Lib.Repositories
{
    //https://stackoverflow.com/questions/35363358/computing-sha1-with-asp-net-core
    public class UserRepository : IRepository<User>
    {
        private Context context;

        public UserRepository(Context context)
        {

            this.context = context;
        }

        public List<User> List()
        {
            return context.Users.ToList();
        }

        public User GetByEmailPass(string email, string password)
        {
            
           List<User> list =  this.context.Users.FromSqlRaw<User>("select * from users where email = '{0}' and password = '{1}' ", email, password).ToList();

             if ( list.Count > 0)
            {
                return list[0];
            }

            return null;
        }



        public bool Add(User entidade)
        {
            if (entidade.id <= 0)
            {
                this.context.Add(entidade);
                return true;
            }
            else
            {
                return false;
            }
        }

        public User Find(int id)
        {
            return this.context.Users.Find(id);
        }

        public void Remove(int id)
        {
            User entidade = context.Users.Find(id);
            context.Users.Remove(entidade);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
