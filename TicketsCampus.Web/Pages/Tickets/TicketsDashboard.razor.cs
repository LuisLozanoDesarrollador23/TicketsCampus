using Microsoft.AspNetCore.Components;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Enum;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Methods;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Response;

namespace TicketsCampus.Web.Pages.Tickets;

public partial class TicketsDashboard
{
    [Inject] private TicketService ServiceTicket { get; set; } = null!;

    private List<TicketSummaryDto>? _ticketSummaries;

    private List<TicketSummaryDto>? _filteredTickets;

    private string? _error;

    private int? _selectedTicketId;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
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
            finally
            {
                StateHasChanged();
            }
        }
    }

    private void ChangeValueList(ChangeEventArgs e)
    {
        if (_ticketSummaries == null) return;
        var value = e.Value?.ToString();
        _filteredTickets = Enum.TryParse<TicketStatus>(value, out var parsed)
            ? _ticketSummaries.Where(s => s.Status == parsed).ToList()
            : _ticketSummaries.ToList();
    }

    private void ShowModal(int id)
    {
        _selectedTicketId = id;
        StateHasChanged();
    }

    private async Task HideModal()
    {
        _selectedTicketId = null;
        _ticketSummaries = await ServiceTicket.GetTicketsAsync();
        StateHasChanged();
    }

    private string GetStatusClass(TicketStatus status)
    {
        return status switch
        {
            TicketStatus.Created => "created",
            TicketStatus.InProgress => "inprogress",
            TicketStatus.Resolved => "resolved",
            _ => "created"
        };
    }
}