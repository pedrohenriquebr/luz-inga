namespace LuzInga.Infra.Context;

using LuzInga.Application;
using LuzInga.Domain.Entities;
using Microsoft.EntityFrameworkCore;



public class LuzIngaContext : DbContext, IDbContext
{
    public LuzIngaContext(DbContextOptions<LuzIngaContext> options)
        : base(options) { }

    public DbSet<Contact> Contact { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>().HasKey(x => x.ContactId);

        modelBuilder.Entity<Contact>().Property(x => x.Name).IsRequired();

        modelBuilder.Entity<Contact>().Property(x => x.Email).IsRequired();
    }
}