using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebExercicios.Infra.Models;

[Table("film_actor")]
[PrimaryKey(nameof(Actor_id), nameof(Film_id))]
public class FilmActor
{
    [ForeignKey("Actor")]
    public int Actor_id { get; set; }
    [ForeignKey("Film")]
    public int Film_id { get; set; }
    public DateTime Last_update { get; set; }

    public Actor Actor { get; set; }
    public Films Film { get; set; }
}
