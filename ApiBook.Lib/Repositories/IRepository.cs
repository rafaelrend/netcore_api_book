using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBook.Lib.Repositories
{
    public interface IRepository<T>
    {
        void Remove(int id);

        T Find(int id);

        void Save();

        bool Add(T entidade);

        List<T> List();
    }
}
