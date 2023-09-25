using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebExercicios.Infra.Database.Models;

namespace WebExercicios.Infra.Database.Models;
[Table("staff")]
public class Staff
{
    [Key]
    public int Staff_id { get; set; }
    public string First_name { get; set; }
    public string Last_name { get; set; }
    [ForeignKey("Address")]
    public int Address_id { get; set; }
    public byte[]? Picture { get; set; }
    public string Email { get; set; }
    [ForeignKey("Store")]
    public int Store_id { get; set; }
    public int Active { get; set; }
    public string Username { get; set; }
    public string? Password { get; set; }
    public DateTime Last_update { get; set; }

    public Addresses Address { get; set; }
    public Store Store { get; set; }
}
