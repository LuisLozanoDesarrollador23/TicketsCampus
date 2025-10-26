namespace TicketsCampus.Service.Interoperability.TicketsAgreement.Methods;

public partial class TicketService
{
    private readonly GeneralConfigurationService _config;

    public TicketService(GeneralConfigurationService config)
    {
        _config = config;
    }
}