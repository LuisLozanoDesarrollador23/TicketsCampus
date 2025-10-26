using System.ComponentModel.DataAnnotations;

namespace TicketsCampus.Web.Pages;

public class CreateTicketForm
{
    /// <summary>
    ///     Titulo del ticket.
    /// </summary>
    [Required(ErrorMessage = "El titulo es requerido")]
    [MinLength(10, ErrorMessage = "El titulo debe tener al menos 10 caracteres")]
    public string Title { get; set; } = null!;

    /// <summary>
    ///     Descripción detallada del ticket.
    /// </summary>
    [Required(ErrorMessage = "La descripción de la resolución es requerida")]
    [MinLength(10, ErrorMessage = "La descripción debe tener al menos 10 caracteres")]
    public string Description { get; set; } = null!;
}