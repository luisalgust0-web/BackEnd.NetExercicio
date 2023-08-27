using Microsoft.EntityFrameworkCore;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Models;

namespace WebExercicios.Infra.Database;
public class ExercicioContext : DbContext
{
    public ExercicioContext(DbContextOptions<ExercicioContext> options) : base(options){ }

    //public DbSet<CategoriaProdutos> CategoriaProdutos { get; set; }
    public DbSet<Films> Film { get; set; }
    public DbSet<Language> Language {get;set;} 
    public DbSet<Citys> City {get; set;}
    public DbSet<Countrys> Country {get; set;}
    public DbSet<Addresses> Address { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<FilmCategory> FilmCategories { get; set; }
    public DbSet<Actor> Actor { get; set; }
    public DbSet<FilmActor> FilmActors{ get; set; }
}