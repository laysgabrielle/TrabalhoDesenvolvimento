using System;
using System.ComponentModel.DataAnnotations;

namespace Floricultura.Application.ViewModels
{
    public class FlorViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome da flor é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter até 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [StringLength(300, ErrorMessage = "A descrição deve ter até 300 caracteres")]
        public string Descricao { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Preco { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O estoque não pode ser negativo")]
        public int Estoque { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    }
}
