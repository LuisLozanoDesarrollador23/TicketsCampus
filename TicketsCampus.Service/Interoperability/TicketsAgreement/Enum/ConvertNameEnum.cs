namespace TicketsCampus.Service.Interoperability.TicketsAgreement.Enum;

public static class ConvertNameEnum
{
    public static string ConvertName(TicketStatus status)
    {
        return status switch
        {
            TicketStatus.InProgress => "En progreso",
            TicketStatus.Resolved => "Resuelto",
            _ => "Creado"
        };
    }
}