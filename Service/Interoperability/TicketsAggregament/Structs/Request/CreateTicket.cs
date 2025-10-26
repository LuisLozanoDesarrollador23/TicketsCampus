namespace TicketsCampus.Service.Interoperability.TicketsAggregament.Structs.Request;

public class CreateTicket
{
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
}
