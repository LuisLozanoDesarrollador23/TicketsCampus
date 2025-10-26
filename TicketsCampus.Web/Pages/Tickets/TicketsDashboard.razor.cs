using Microsoft.AspNetCore.Components;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Methods;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Response;

namespace TicketsCampus.Web.Pages.Tickets;

public partial class TicketsDashboard
{
    [Inject] private TicketService ServiceTicket { get; set; } = null!;

    private List<TicketSummary>? _ticketSummaries;

    private string? _error;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _ticketSummaries = await ServiceTicket.GetTicketsAsync();
        }
        catch (Exception e)
        {
            _error = e.Message;
        }
    }
}