using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebExercicios.Infra.Database.Models;
[Table("payment")]
public class Payment
{
   [Key]
   public int Payment_id {get; set;}
   [ForeignKey("Customer")]
   public int Customer_id {get; set;}
   [ForeignKey("Staff")]
   public int Staff_id {get; set;}
   [ForeignKey("Rental")]
   public int Rental_id {get; set;}
   public decimal Amount {get; set;}
   public DateTime Payment_date {get; set;}
   public DateTime Last_update {get; set;}

   public Customer Customer { get; set; }
   public Staff Staff { get; set; }
   public Rental Rental { get; set;}
}
