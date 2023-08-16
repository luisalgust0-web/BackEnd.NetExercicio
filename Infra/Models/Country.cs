using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebExercicios.Infra.Models;
[Table("country")]
public class Countrys
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Country_id {get; set;}
    public string Country { get; set; }
    public DateTime Last_update { get; set; }
}
