using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebExercicios.Infra.Models;
[Table("category")]
public class Category
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Category_id { get; set; }
    public string Name { get; set; }
    public DateTime Last_update { get; set; }

    public List<FilmCategory> filmCategories { get; set; }
}
