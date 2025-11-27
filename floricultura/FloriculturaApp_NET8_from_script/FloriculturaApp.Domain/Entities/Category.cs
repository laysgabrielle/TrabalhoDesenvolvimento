namespace FloriculturaApp.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Relacionamento 1:N com Product
        public ICollection<Product>? Products { get; set; }
    }
}
