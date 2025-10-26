using TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Request;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Response;

namespace TicketsCampus.Service.Interoperability.TicketsAgreement.Methods;

public partial class TicketService
{
    public Task<TicketDetailDto?> CreateTicketByIdAsync(CreateTicket? form)
    {
        try
        {
            if (form == null)
            {
                throw new Exception("El objeto suministrado no puede ser nulo");
            }

            return _config.PostAsJsonAsync<CreateTicket, TicketDetailDto>($"tickets", form);
        }
        catch (Exception e)
        {
            throw new Exception($"Error al crear el ticket: {e.Message}");
        }
    }
}