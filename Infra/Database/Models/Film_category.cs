using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WebExercicios.Infra.Database.Models;

namespace WebExercicios.Infra.Database.Models;
[Table("film_category")]
[PrimaryKey(nameof(Film_id),nameof(Category_id))]
public class Film_category
{
    [ForeignKey("Film")]
    public int Film_id {get;set;}
    [ForeignKey("Category")]
    public int Category_id {get;set;}
    public DateTime Last_update {get;set;}

    public Film Film { get; set; }
    public Category Category { get; set; }
}
