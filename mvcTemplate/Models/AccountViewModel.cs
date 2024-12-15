using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace mvc.Models
{
    public class AccountViewModel
    {
        [Required(ErrorMessage = "L'email est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'adresse e-mail est invalide.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [PasswordPolicy]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Veuillez confirmer le mot de passe.")]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        [DataType(DataType.Password)]
        public required string ConfirmedPassword { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères.")]
        public required string Firstname { get; set; }

        [Required(ErrorMessage = "Le nom de famille est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le nom de famille ne peut pas dépasser 50 caractères.")]
        public required string Lastname { get; set; }

        [Url(ErrorMessage = "L'URL du site personnel est invalide.")]
        public required string PersonalWebSite { get; set; }

        public bool IsTeacher { get; set; }
    }

    /// <summary>
    /// </summary>
    public class PasswordPolicyAttribute : ValidationAttribute
    {
#pragma warning disable
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
#pragma warning restore CS8765 
        {
            string? password = value as string;

            if (string.IsNullOrEmpty(password))
                return new ValidationResult("Le mot de passe est obligatoire.");

            // Règles définies dans Identity
            if (password.Length < 6)
                return new ValidationResult("Le mot de passe doit contenir au moins 6 caractères.");
            if (!Regex.IsMatch(password, @"\d"))
                return new ValidationResult("Le mot de passe doit contenir au moins un chiffre.");
            if (!Regex.IsMatch(password, @"[a-z]"))
                return new ValidationResult("Le mot de passe doit contenir au moins une lettre minuscule.");
            if (!Regex.IsMatch(password, @"[A-Z]"))
                return new ValidationResult("Le mot de passe doit contenir au moins une lettre majuscule.");
            if (!Regex.IsMatch(password, @"[\W_]"))
                return new ValidationResult("Le mot de passe doit contenir au moins un caractère spécial (par ex. !, @, #, etc.).");

#pragma warning disable CS8603
            return ValidationResult.Success;
#pragma warning restore CS8603 
        }
    }
}
