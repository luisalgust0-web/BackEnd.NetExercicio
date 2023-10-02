using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Namespace;
using WebExercicios.Infra.Exceptions;

namespace WebExercicios.Infra.Database.Models;
[Table("rental")]
public class Rental
{
   [Key]
   public int Rental_id {get; set;}
   public DateTime? Rental_date {get; set;}
   [ForeignKey("Inventory")]
   public int Inventory_id {get; set;}
   [ForeignKey("Customer")]
   public int Customer_id {get; set;}
   public DateTime? Return_date {get; set;}
   [ForeignKey("Staff")]
   public int Staff_id {get; set;}
   public DateTime Last_update {get; set;}
   public DateTime Forecast_date { get; set; }
   public TipoSituacao Situacao { get; set; }


   public Customer Customer { get; set; }
   public Inventory Inventory { get; set; }
   public Staff Staff { get; set; }

}


 public enum TipoSituacao {
  alugado = 1 ,
  devolvido = 2,
  pago = 3 
  }

public static class TipoSituacaoMetodos{

   public static TipoSituacao StringToTipoSituacao(this string value){
        switch (value)
      {
         case "alugado":
          return TipoSituacao.alugado;
         case "devolvido":
          return TipoSituacao.devolvido;
         case "pago":
          return TipoSituacao.pago;
         default:
          throw new LocadoraFilmeException("Situação inexistente");
      }
   }

   public static string TipoSituacaoToString(this TipoSituacao tipo){
      switch(tipo)
      {
         case TipoSituacao.alugado:
          return "alugado";
         case TipoSituacao.devolvido:
          return "devolvido";
         case TipoSituacao.pago:
          return "pago";
         default:
          throw new LocadoraFilmeException("Situação inexistente");
      }
   }

}