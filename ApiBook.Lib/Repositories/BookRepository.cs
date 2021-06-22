using System;
using System.Collections.Generic;
using System.Text;
using ApiBook.Lib.DAL;
using ApiBook.Lib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;

namespace ApiBook.Lib.Repositories
{
    public class BookRepository : IRepository<Book>
    {


        private Context context;

        public BookRepository(Context context)
        {

            this.context = context;
        }
        public bool Add(Book entidade)
        {
            throw new NotImplementedException();
        }

        public Book Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> List()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public object getList(string filtro = "")
        {
            var context = this.context;

            var query = (from b in context.Books
                        join a in context.Authors on b.author_id equals a.id
                        let author_name = a.name
                        select new { b.id, b.isbn, b.title, b.price, b.date_release, author_name });

            if (filtro != null && filtro != String.Empty)
            {
                query.Where(x => x.title.ToLower().Contains(filtro.ToLower()) ||
                      x.isbn.ToLower().Contains(filtro.ToLower()) ||
                      x.author_name.ToLower().Contains(filtro.ToLower()));
            }

            return query.ToList();

            //           join auth in db.Authors on auth.id equals book.id
            //         select new { book, auth.name }
                           /*
                this.context.Books.FromSqlRaw<Book>(@"select b.*, a.name as author_name from book b
                                        left join author a on a.id = b.author_id").Include(x=>x.author_name)
                                        */
        }
    }
}
