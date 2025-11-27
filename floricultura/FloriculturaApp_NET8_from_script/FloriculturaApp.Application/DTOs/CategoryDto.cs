using System.ComponentModel.DataAnnotations;
using FloriculturaApp.Application.Validations;

namespace FloriculturaApp.Application.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        [StringLength(100, MinimumLength = 3, 
            ErrorMessage = "O nome deve ter entre 3 e 100 caracteres")]
        [NomeNaoVazio]
        public string Name { get; set; } = string.Empty;
    }
}
