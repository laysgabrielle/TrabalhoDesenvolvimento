using System.ComponentModel.DataAnnotations;

namespace FloriculturaApp.Application.Validations
{
    /// <summary>
    /// Validação personalizada para garantir que o preço seja positivo (maior que zero).
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PrecoPositivoAttribute : ValidationAttribute
    {
        public PrecoPositivoAttribute()
        {
            ErrorMessage = "O preço deve ser maior que zero.";
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
                return true;

            if (decimal.TryParse(value.ToString(), out decimal price))
            {
                return price > 0;
            }

            return false;
        }
    }
}
