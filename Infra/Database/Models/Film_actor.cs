using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebExercicios.Infra.Database.Models;
[Table("film_actor")]
[PrimaryKey(nameof(Actor_id),nameof(Film_id))]
public class Film_actor
{
    [ForeignKey("Actor")]
    public int Actor_id {get; set;}
    [ForeignKey("Film")]
    public int Film_id {get; set;}
    public DateTime Last_update {get; set;}

    public Actor Actor {get; set;}
    public Film Film {get; set;}
}
