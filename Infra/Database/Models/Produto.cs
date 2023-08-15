using System.ComponentModel.DataAnnotations.Schema;

namespace WebExercicios.Infra.Database.Models;
public class Produto
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set;}
    public string Nome { get; set;}
    public int CategoriaProdutosId { get; set;}

    public CategoriaProdutos CategoriaProdutos { get; set; }
}
