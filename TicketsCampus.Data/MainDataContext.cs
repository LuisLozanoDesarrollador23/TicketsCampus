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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.TicketDetail)
            .WithOne(d => d.Ticket)
            .HasForeignKey<TicketDetail>(d => d.TicketId)
            .OnDelete(DeleteBehavior.Cascade);        
    }
}
