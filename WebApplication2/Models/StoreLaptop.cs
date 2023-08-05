namespace WebApplication2.Models
{
    public class StoreLaptop
    {
        public Guid Id { get; set; }
        public Guid Laptopid { get; set; }
        public Laptop Laptop { get; set; }
        public Guid StoreId { get; set; }
        public StoreLocation StoreLocation { get; set; }
        public int LaptopStock { get; set; }
    }
}
