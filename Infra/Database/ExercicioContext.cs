using Microsoft.EntityFrameworkCore;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Models;

namespace WebExercicios.Infra.Database;
public class ExercicioContext : DbContext
{
    public ExercicioContext(DbContextOptions<ExercicioContext> options) : base(options){ }

    //public DbSet<CategoriaProdutos> CategoriaProdutos { get; set; }

    public DbSet<Countrys> Country {get; set;}
}