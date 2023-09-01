using Practica3.EF.Data;
using Practica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF.Logic
{
    public class CustomersLogic : BaseLogic
    {

        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }
    }
}
