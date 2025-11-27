namespace FloriculturaApp.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Relacionamento com Category
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
