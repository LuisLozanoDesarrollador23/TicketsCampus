using System.ComponentModel.DataAnnotations;

namespace TicketsCampus.Web.Pages.Tickets.Components;

public class UpdateTicketForm
{
    [Required(ErrorMessage = "La descripción de la resolución es requerida")]
    [MinLength(10, ErrorMessage = "La descripción debe tener al menos 10 caracteres")]
    public string Description { get; set; } = null!;
}