using TicketsCampus.Service.Interoperability.TicketsAggregament.Enum;

namespace TicketsCampus.Data.Models;

public class Ticket
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; }    
    public TicketStatus Status { get; set; }    
}
