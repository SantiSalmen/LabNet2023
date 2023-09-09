using Practica3.EF.Data;

namespace Practica3.EF.Logic
{
    public class BaseLogic
    {
        protected readonly NorthwindContext context;

        public BaseLogic()
        {
            context = new NorthwindContext();

        }

    }
}
