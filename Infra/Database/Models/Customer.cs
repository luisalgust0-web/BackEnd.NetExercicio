using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebExercicios.Infra.Database.Models;
[Table("customer")]
public class Customer
{
   [Key]
   public int Customer_id {get; set;}
   [ForeignKey("Store")]
   public int Store_id {get; set;}
   public string First_name {get; set;}
   public string Last_name {get; set;}
   public string Email {get; set;}
   [ForeignKey("Address")]
   public int Address_id {get; set;}
   public int Active {get; set;}
   public DateTime Create_date {get; set;}
   public DateTime Last_update {get; set;}

   public Store Store { get; set; } 
   public Addresses Address { get; set; }
}
