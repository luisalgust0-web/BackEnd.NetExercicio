using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebExercicios.Infra.Models;
[Table("language")]
public class Language
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Language_id { get; set; }
    public string Name { get; set; }
    public DateTime Last_update { get; set; }
}
