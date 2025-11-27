using System.ComponentModel.DataAnnotations;
using FloriculturaApp.Application.Validations;

namespace FloriculturaApp.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [StringLength(150, MinimumLength = 3, 
            ErrorMessage = "O nome deve ter entre 3 e 150 caracteres")]
        [NomeNaoVazio]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O preço é obrigatório")]
        [PrecoPositivo]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória")]
        public int CategoryId { get; set; }
    }
}
