using Microsoft.EntityFrameworkCore;
using TicketsCampus.Data;
using TicketsCampus.Data.Models;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Enum;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Request;
using TicketsCampus.Service.Interoperability.TicketsAgreement.Structs.Response;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5154);
    options.ListenAnyIP(7290, listenOptions => { listenOptions.UseHttps(); });
});

builder.Services.AddDbContext<MainDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy =>
    {
        policy.WithOrigins("https://localhost:7147")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors("AllowBlazor");


app.MapGet("/", () => "Hello World!");

// Crear un nuevo ticket
app.MapPost("/tickets", async (CreateTicket ticket, MainDataContext db) =>
{
    var createTicket = new Ticket
    {
        Title = ticket.Title,
        Description = ticket.Description,
        CreatedAt = ticket.CreatedAt,
        Status = TicketStatus.Created
    };

    db.Tickets.Add(createTicket);
    await db.SaveChangesAsync();
    return Results.Created($"/tickets/{createTicket.Id}", ticket);
});

// Obtener todos los tickets
app.MapGet("/tickets", async (MainDataContext db) =>
    await db.Tickets
        .Select(t => new TicketSummaryDto(t.Id, t.Title, t.CreatedAt, t.Status))
        .ToListAsync());

// Obtener un ticket por ID
app.MapGet("/tickets/{id:int}", async (int id, MainDataContext db) =>
{
    var ticket = await db.Tickets
        .Include(t => t.TicketDetail)
        .FirstOrDefaultAsync(t => t.Id == id);

    if (ticket == null)
        return Results.NotFound();

    var dto = new TicketDetailDto(
        ticket.Id,
        ticket.Title,
        ticket.Description,
        ticket.CreatedAt,
        ticket.Status,
        ticket.TicketDetail?.Description,
        ticket.TicketDetail?.CreatedAt
    );

    return Results.Ok(dto);
});

// Actualizar un ticket (solo estado)
app.MapPatch("/tickets/{id:int}", async (int id, UpdateTicket updatedTicket, MainDataContext db) =>
{
    var ticket = await db.Tickets.Include(s => s.TicketDetail).FirstOrDefaultAsync(t => t.Id == id);
    if (ticket is null) return Results.NotFound();

    ticket.Status = TicketStatus.Resolved;
    ticket.TicketDetail = new TicketDetail
    {
        Description = updatedTicket.Description,
        CreatedAt = updatedTicket.DateUpdate
    };

    await db.SaveChangesAsync();

    var dto = new TicketDetailDto(
        ticket.Id,
        ticket.Title,
        ticket.Description,
        ticket.CreatedAt,
        ticket.Status,
        ticket.TicketDetail?.Description,
        ticket.TicketDetail?.CreatedAt
    );

    return Results.Ok(dto); 
});

app.Run();