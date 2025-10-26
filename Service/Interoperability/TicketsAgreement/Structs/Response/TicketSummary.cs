using TicketsCampus.Service.Interoperability.TicketsAgreement.Enum;

namespace TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Response;

public record TicketSummary(int Id, string Title, DateTime Created, TicketStatus Status);