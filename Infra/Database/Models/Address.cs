using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebExercicios.Infra.Database.Models;
[Table("address")]
public class Addresses
{
    [Key]
    public int Address_id { get; set; }
    public string District { get; set; }
    public string Address { get; set; }
    public string? Address2 { get; set; }
    public int Phone { get; set; }
    public int Postal_code { get; set; }
    public DateTime Last_update { get; set; }
    [ForeignKey("City")]
    public int City_id { get; set; }

    public Citys City { get; set; }
}
