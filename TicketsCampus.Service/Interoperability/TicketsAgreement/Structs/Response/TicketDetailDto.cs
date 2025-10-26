using TicketsCampus.Service.Interoperability.TicketsAgreement.Enum;

namespace TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Response;

public record TicketDetailDto(
    int Id,
    string Title,
    string Details,
    DateTime Created,
    TicketStatus Status,
    string? DescriptionResolved,
    DateTime? DateResolved);