using Microsoft.AspNetCore.Components;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Enum;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Methods;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Response;

namespace TicketsCampus.Web.Pages.Tickets;

public partial class TicketsDashboard
{
    /// <summary>
    ///     Servicio inyectado para los metodos de rest para la entidad de tickets
    /// </summary>
    [Inject]
    private TicketService ServiceTicket { get; set; } = null!;

    /// <summary>
    ///     Listado de ticktes creados
    /// </summary>
    /// <remarks>
    ///     Cuando se hace le primer render, trae del api todos los registros, localmente se guarda en esta lista
    ///     para posteriormente utilizarla en los filtrados.
    /// </remarks>
    private List<TicketSummaryDto>? _ticketSummaries;

    /// <summary>
    ///     Listado que se utiliza para la visualización de los registros en la vista
    /// </summary>
    private List<TicketSummaryDto>? _filteredTickets;

    /// <summary>
    ///     Permite guardar el mensaje de error para mostrar al usuario
    /// </summary>
    private string? _error;

    /// <summary>
    ///     Identificador del ticket seleccionado
    /// </summary>
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
        _filteredTickets = _ticketSummaries;
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