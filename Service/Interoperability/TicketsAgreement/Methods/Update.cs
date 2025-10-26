using TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Request;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Response;

namespace TicketsCampus.Service.Interoperability.TicketsAgreement.Methods;

public partial class TicketService
{
    public Task<TicketDetailDto?> UpdateTicketByIdAsync(UpdateTicket? form)
    {
        try
        {
            if (form == null)
            {
                throw new Exception("El objeto suministrado no puede ser nulo");
            }

            return _config.PatchAsJsonAsync<UpdateTicket, TicketDetailDto>($"tickets/{form.Id}", form);
        }
        catch (Exception e)
        {
            throw new Exception($"Error al obtener el ticket: {e.Message}");
        }
    }
}