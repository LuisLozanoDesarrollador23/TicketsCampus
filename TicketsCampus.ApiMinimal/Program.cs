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
        .Select(t => new TicketSummary(t.Id, t.Title, t.CreatedAt, t.Status))
        .ToListAsync());

// Obtener un ticket por ID
app.MapGet("/tickets/{id:int}", async (int id, MainDataContext db) =>
    await db.Tickets.FindAsync(id)
        is Ticket ticket
        ? Results.Ok(ticket)
        : Results.NotFound());

// Actualizar un ticket (solo estado)
app.MapPut("/tickets/{id:int}", async (int id, Ticket updatedTicket, MainDataContext db) =>
{
    var ticket = await db.Tickets.FindAsync(id);
    if (ticket is null) return Results.NotFound();

    ticket.Status = updatedTicket.Status;
    await db.SaveChangesAsync();
    return Results.Ok(ticket);
});

app.Run();