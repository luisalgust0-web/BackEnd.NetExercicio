using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebExercicios.Infra.Database.Models;

namespace Namespace;
[Table("inventory")]
public class Inventory
{
   [Key]
   public int Inventory_id {get;set;}
   [ForeignKey("Film")]
   public int Film_id {get;set;}
   [ForeignKey("Store")]
   public int Store_id {get;set;}
   public DateTime Last_update {get;set;}

   public Film Film { get; set; }
   public Store Store { get; set; }

}
