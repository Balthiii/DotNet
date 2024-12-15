using System;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre est requis.")]
        [StringLength(100, ErrorMessage = "Le titre ne peut pas dépasser 100 caractères.")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "La description est requise.")]
        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères.")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "La date de l'événement est requise.")]
        [DataType(DataType.DateTime, ErrorMessage = "La date de l'événement est invalide.")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Le nombre maximum de participants est requis.")]
        [Range(10, 200, ErrorMessage = "Le nombre maximum de participants doit être entre 10 et 200.")]
        public int MaxParticipants { get; set; }

        [Required(ErrorMessage = "Le lieu est requis.")]
        [StringLength(100, ErrorMessage = "Le lieu ne peut pas dépasser 100 caractères.")]
        public required string Location { get; set; }

        [Display(Name = "Date de création")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
