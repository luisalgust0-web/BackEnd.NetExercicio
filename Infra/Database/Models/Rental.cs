using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Namespace;

namespace WebExercicios.Infra.Database.Models;
[Table("rental")]
public class Rental
{
   [Key]
   public int Rental_id {get; set;}
   public DateTime Rental_date {get; set;}
   [ForeignKey("Inventory")]
   public int Inventory_id {get; set;}
   [ForeignKey("Customer")]
   public int Customer_id {get; set;}
   public DateTime Return_date {get; set;}
   [ForeignKey("Staff")]
   public int Staff_id {get; set;}
   public DateTime Last_update {get; set;}

   public Customer Customer { get; set; } 
   public Inventory Inventory { get; set; }
   public Staff Staff { get; set; }

}
