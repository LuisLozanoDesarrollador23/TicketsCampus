using TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Response;

namespace TicketsCampus.Service.Interoperability.TicketsAgreement.Methods;

public partial class TicketService
{
    public Task<List<TicketSummary>?> GetTicketsAsync()
    {
        return _config.GetFromJsonAsync<List<TicketSummary>>("tickets");
    }
}