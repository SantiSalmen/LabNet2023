using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
