using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebExercicios.Infra.Database.Models;
[Table("city")]
public class Citys
{
    [Key]
    public int City_id {get;set;}
    [ForeignKey("Country")]
    public int Country_id {get;set;}
    public string City {get;set;}
    public DateTime Last_update {get;set;}
    public Countrys Country { get; set; }
}
