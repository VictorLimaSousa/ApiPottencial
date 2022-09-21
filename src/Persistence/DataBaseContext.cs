using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

public class DataBaseContext : DbContext
{
    public DataBaseContext
    (DbContextOptions<DataBaseContext> options):base(options)
    {
        
    }
    
    public DbSet<Person> Pessoas { get; set; }
    public DbSet<Contract> Contratos { get; set; }

    protected void OnModelCreating (ModelBuilder builder)
    {
        builder.Entity<Person>(p =>{
            p.HasKey(e => e.Id);
            p.HasMany(e => e.Constratos)
            .WithOne()
            .HasForeignKey(e => e.PessoaId);});

        builder.Entity<Contract>(c =>{c.HasKey(e =>e.Id);});
    }

    
}