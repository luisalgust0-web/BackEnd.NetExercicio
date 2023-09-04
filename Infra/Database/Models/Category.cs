using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebExercicios.Infra.Database.Models;
[Table("category")]
public class Category
{
    [Key]
    public int Category_id { get; set; }
    public string Name { get; set; }
    public DateTime Last_update { get; set; }
}
