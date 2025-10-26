using System.ComponentModel.DataAnnotations;

namespace TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Request;

public class UpdateTicket
{
    [Required(ErrorMessage = "El identificador es requerido")]
    public int Id { get; set; }

    [Required(ErrorMessage = "La descripción de la resolución es requerida")]
    [MinLength(10, ErrorMessage = "La descripción debe tener al menos 10 caracteres")]
    public string Description { get; set; } = null!;

    public DateTime DateUpdate { get; set; }
}