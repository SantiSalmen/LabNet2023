using System.Collections.Generic;

namespace Practica3.EF.Entities
{
    public interface ILogic<T>
    {
        List<T> GetAll();

        void Add (T entity);

        void Update (T entity);
        void Delete(T entity);
    }
}
