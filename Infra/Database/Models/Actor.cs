using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebExercicios.Infra.Database.Models;
[Table("actor")]
public class Actor
{
    [Key]
    public int Actor_id { get; set; }
    public string First_name {get; set;}
    public string Last_name {get; set;}
    public DateTime Last_update {get; set;}

}
