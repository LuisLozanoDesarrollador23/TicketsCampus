using TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Response;

namespace TicketsCampus.Service.Interoperability.TicketsAgreement.Methods;

public partial class TicketService
{
    public Task<TicketDetailDto?> GetTicketByIdAsync(int? id)
    {
        try
        {
            if (!id.HasValue)
            {
                throw new Exception($"No se suministro un identificador para realizar la consulta");
            }

            return _config.GetFromJsonAsync<TicketDetailDto>($"tickets/{id}");
        }
        catch (Exception e)
        {
            throw new Exception($"Error al obtener el ticket: {e.Message}");
        }
    }
}