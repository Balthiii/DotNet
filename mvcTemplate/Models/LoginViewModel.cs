using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "L'adresse email est obligatoire.")]
        [EmailAddress(ErrorMessage = "Veuillez fournir une adresse email valide.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        public bool RememberMe { get; internal set; }
    }
}

