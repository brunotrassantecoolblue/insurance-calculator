namespace Insurance.Domain.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductTypeId { get; set; }
        public float SalesPrice { get; set; }
    }
}