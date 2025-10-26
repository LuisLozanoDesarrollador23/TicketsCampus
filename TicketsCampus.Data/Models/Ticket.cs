using System.ComponentModel.DataAnnotations;
using TicketsCampus.Service.Interoperability.TicketsAggregament.Enum;

namespace TicketsCampus.Data.Models;

/// <summary>
///     Representa la entidad de un ticket en el sistema de gestión de tickets.
/// </summary>
public class Ticket
{
    /// <summary>
    ///     Identificador único del ticket autoincrementado.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    ///     Titulo del ticket.
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    ///     Descripción detallada del ticket.
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    ///     Fecha y hora de creación del ticket.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///     Estado actual del ticket.
    /// </summary>
    public TicketStatus Status { get; set; }    
}
