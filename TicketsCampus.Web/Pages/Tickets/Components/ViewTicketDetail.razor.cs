using Microsoft.AspNetCore.Components;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Methods;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Request;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Response;

namespace TicketsCampus.Web.Pages.Tickets.Components;

public partial class ViewTicketDetail
{
    [Parameter] public int? TicketId { get; set; }
    [Parameter] public EventCallback OnClose { get; set; }
    [Parameter] public EventCallback OnTicketResolved { get; set; }
    [Inject] private TicketService ServiceTicket { get; set; } = null!;

    private UpdateTicketForm ResolutionModel { get; set; } = new();
    private bool IsSubmitting { get; set; }
    private string? ResolutionError { get; set; }

    private TicketDetailDto? Ticket { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            try
            {
                Ticket = await ServiceTicket.GetTicketByIdAsync(TicketId);
            }
            catch (Exception e)
            {
                ResolutionError = e.Message;
            }
        }
    }

    private async Task Close()
    {
        await OnClose.InvokeAsync();
    }

    private async Task HandleResolveTicket()
    {
        IsSubmitting = true;
        ResolutionError = null;

        try
        {
            var updateRequest = new UpdateTicket
            {
                Id = TicketId!.Value,
                DateUpdate = DateTime.Now,
                Description = ResolutionModel.Description
            };

            await ServiceTicket.UpdateTicketByIdAsync(updateRequest);
            await OnTicketResolved.InvokeAsync();
            await Close();
        }
        catch (Exception ex)
        {
            ResolutionError = $"Error al gestionar el ticket: {ex.Message}";
        }
        finally
        {
            IsSubmitting = false;
        }
    }
}