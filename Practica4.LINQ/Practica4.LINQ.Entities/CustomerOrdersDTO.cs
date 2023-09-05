namespace Practica4.LINQ.Entities
{
    public class CustomerOrdersDTO
    {
        public Customers customer { get; set; }

        public int associatedOrders { get; set; }
    }
}
