using Microsoft.AspNetCore.Components;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Methods;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Request;

namespace TicketsCampus.Web.Pages;

public partial class Home
{
    [Inject] private TicketService ServiceTicket { get; set; } = null!;

    [Inject] private NavigationManager Nav { get; set; } = null!;

    private CreateTicket _ticket = new();

    private string? _successMessage;

    private async Task HandleValidSubmit()
    {
        _ticket.CreatedAt = DateTime.Now;
        await ServiceTicket.CreateTicketByIdAsync(_ticket);

        _successMessage = $"Ticket '{_ticket.Title}' creado exitosamente el {_ticket.CreatedAt:g}.";
        Nav.NavigateTo("/tickets");
        _ticket = new CreateTicket();
    }
}