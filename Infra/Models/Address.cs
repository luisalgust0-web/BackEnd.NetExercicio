using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace WebExercicios.Infra.Models;

[Table("address")]
public class Addresses
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Address_id { get; set; }
    public string Address { get; set; }
    public string? Address2 { get; set; }
    public string District { get; set; }
    [ForeignKey("City")]
    public int City_id { get; set; }
    public string Postal_code { get; set; }
    public string Phone { get; set; }
    public DateTime Last_update { get; set; }

    public Citys City { get; set; }
}
