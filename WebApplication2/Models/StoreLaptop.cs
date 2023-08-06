namespace WebApplication2.Models
{
    public class StoreLaptop
    {
        public Guid Id { get; set; }
        public Laptop Laptop { get; set; }
        public Guid LaptopId { get; set; }
        public StoreLocation Store { get; set; }
        public Guid StoreId { get; set; }
        public int LaptopStock { get; set; }
    }
}
