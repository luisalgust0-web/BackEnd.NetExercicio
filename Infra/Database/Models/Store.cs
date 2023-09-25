using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Namespace;

namespace WebExercicios.Infra.Database.Models;
[Table("store")]
public class Store
{
    [Key]
    public int Store_id { get; set; }
    [ForeignKey("Address")]
    public int Address_id {get;set;}
    [ForeignKey("Staff")]
    public int Manager_staff_id {get;set;}
    public DateTime Last_update {get;set;}

    public Addresses Address { get; set; }
    public Staff Staff { get; set; }

}
