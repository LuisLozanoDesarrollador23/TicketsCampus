namespace TicketsCampus.Data.Models;

/// <summary>
///     Entidad que guarda la respuesta del ticket.
/// </summary>
public class TicketDetail
{
    /// <summary>
    ///     Identificador autogenerado de la respuesta del ticket.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Detalle de la respuesta del ticket.
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    ///     Fecha de creación del registro.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    public int TicketId { get; set; }

    public Ticket Ticket { get; set; } = null!;    

}
