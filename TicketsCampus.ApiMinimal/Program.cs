using Microsoft.EntityFrameworkCore;
using TicketsCampus.Data;


var builder = WebApplication.CreateBuilder(args);

// Agregar DbContext
builder.Services.AddDbContext<MainDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
