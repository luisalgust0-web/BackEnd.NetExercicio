using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebExercicios.Infra.Models;
[Table("film_category")]
[PrimaryKey(nameof(Category_id), nameof(Film_id))]
public class FilmCategory
{
    [ForeignKey("Film")]
    public int Film_id { get; set; }
    [ForeignKey("Category")]    
    public int Category_id { get; set; }
    public DateTime Last_update { get; set; }

    public Films Film { get; set; }
    public Category Category { get; set; }
}
