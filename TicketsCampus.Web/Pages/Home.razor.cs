using Microsoft.AspNetCore.Components;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Methods;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Request;

namespace TicketsCampus.Web.Pages;

public partial class Home
{
    /// <summary>
    ///     Servicio inyectado para los metodos de rest para la entidad de tickets
    /// </summary>
    [Inject]
    private TicketService ServiceTicket { get; set; } = null!;

    /// <summary>
    ///     Servicio inyectado para la gestión de navegación entre paginas
    /// </summary>
    [Inject]
    private NavigationManager Nav { get; set; } = null!;

    /// <summary>
    ///     Formulario de creación establecido en el cliente
    /// </summary>
    private CreateTicketForm _ticket = new();

    /// <summary>
    ///     Mensaje de resultado del proceso de creación
    /// </summary>
    private string? _successMessage;

    /// <summary>
    ///     Función para la creación de un tiicket, una vez creado se envía a la vista
    ///     del dashboard de tickets
    /// </summary>
    private async Task HandleValidSubmit()
    {
        var spec = new CreateTicket
        {
            Title = _ticket.Title,
            Description = _ticket.Description,
            CreatedAt = DateTime.Now
        };

        await ServiceTicket.CreateTicketByIdAsync(spec);

        _successMessage = $"Ticket '{_ticket.Title}' creado exitosamente el {spec.CreatedAt:g}.";
        Nav.NavigateTo("/tickets");
        _ticket = new CreateTicketForm();
    }
}