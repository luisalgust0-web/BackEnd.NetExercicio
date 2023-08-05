using Microsoft.EntityFrameworkCore;
using WebExercicios.Infra.Database.Models;

namespace WebExercicios.Infra.Database;
public class ExercicioContext : DbContext
{
    public ExercicioContext(DbContextOptions<ExercicioContext> options) : base(options){ }

    public DbSet<CategoriaProdutos> CategoriaProdutos { get; set; }
}
