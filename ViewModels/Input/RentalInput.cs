using WebExercicios.Infra.Database.Models;

namespace WebExercicios.ViewModels.Input;
public class RentalInput
{
    public int Rental_id { get; set; }
    public DateTime Rental_date { get; set; }
    public int Inventory_id { get; set; }
    public int Customer_id { get; set; }
    public DateTime? Return_date { get; set; }
    public int Staff_id { get; set; }
    public DateTime Last_update { get; set; }
    public DateTime Forecast_date { get; set; }
    public TipoSituacao Situacao {get; set;}
}
