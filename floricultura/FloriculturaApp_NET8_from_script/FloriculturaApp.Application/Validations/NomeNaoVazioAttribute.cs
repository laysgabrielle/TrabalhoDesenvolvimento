using System.ComponentModel.DataAnnotations;

namespace FloriculturaApp.Application.Validations
{
    /// <summary>
    /// Validação personalizada para garantir que o nome não seja vazio ou contenha apenas espaços.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NomeNaoVazioAttribute : ValidationAttribute
    {
        public NomeNaoVazioAttribute()
        {
            ErrorMessage = "O nome não pode estar vazio ou conter apenas espaços.";
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
                return false;

            string? stringValue = value as string;
            return !string.IsNullOrWhiteSpace(stringValue);
        }
    }
}
