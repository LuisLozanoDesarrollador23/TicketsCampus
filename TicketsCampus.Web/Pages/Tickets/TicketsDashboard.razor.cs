using Microsoft.AspNetCore.Components;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Methods;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Response;

namespace TicketsCampus.Web.Pages.Tickets;

public partial class TicketsDashboard
{
    [Inject] private TicketService ServiceTicket { get; set; } = null!;

    private List<TicketSummaryDto>? _ticketSummaries;

    private List<TicketSummaryDto>? _filteredTickets;

    private string? _error;

    private int? SelectedTicketId;

    private bool ShowDetailModal;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _ticketSummaries = await ServiceTicket.GetTicketsAsync();
            _filteredTickets = _ticketSummaries;
        }
        catch (Exception e)
        {
            _error = e.Message;
        }
    }

    private void ShowModal(int id)
    {
        SelectedTicketId = id;
        ShowDetailModal = true;
    }

    private async Task HideModal()
    {
        ShowDetailModal = false;
        _ticketSummaries = await ServiceTicket.GetTicketsAsync();
        StateHasChanged();
    }
}