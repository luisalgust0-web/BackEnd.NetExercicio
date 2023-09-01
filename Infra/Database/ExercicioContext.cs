using Microsoft.EntityFrameworkCore;
using WebExercicios.Infra.Database.Models;

namespace WebExercicios.Infra.Database;
public class ExercicioContext : DbContext
{
    public ExercicioContext(DbContextOptions<ExercicioContext> options) : base(options){ }

    public DbSet<Film> Film { get; set; }
    public DbSet<Language> Language { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Actor> Actor { get; set; }
    public DbSet<Film_category> Film_Category { get; set; }
    public DbSet<Film_actor> Film_actor { get; set; }
    public DbSet<Countrys> Country { get; set; }
    public DbSet<Addresses> Address { get; set; }
    public DbSet<Citys> City { get; set; }
    public DbSet<Store> Store  { get; set; }
    public DbSet<Staff> Staff { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Rental> Rental { get; set; }
}
    