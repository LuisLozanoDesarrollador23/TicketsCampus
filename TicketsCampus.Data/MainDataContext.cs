using Microsoft.EntityFrameworkCore;
using TicketsCampus.Data.Models;

namespace TicketsCampus.Data;

public class MainDataContext : DbContext
{
    public MainDataContext(DbContextOptions<MainDataContext> options) : base(options)
    {
    }

    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketDetail> TicketDetails { get; set; }
}
