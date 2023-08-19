using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebExercicios.Infra.Models;

namespace WebExercicios.Infra.Models;
[Table("city")]
public class Citys
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int City_id { get; set; }
    public string City { get; set; }
    [ForeignKey("Country")]
    public int Country_id { get; set; }
    public DateTime Last_update { get; set; }

    public Countrys Country { get; set; }
    public List<Addresses> Address { get; set; }
}
