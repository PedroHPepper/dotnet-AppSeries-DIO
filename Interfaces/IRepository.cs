using System;
using System.Collections.Generic;
using System.Text;

namespace Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T ReturnById(int Id);
        void Insert(T entity);
        void Delete(int Id);
        void Update(int Id, T entity);
        int NextId();
    }
}
