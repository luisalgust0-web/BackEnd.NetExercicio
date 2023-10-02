using WebExercicios.Infra.Database.Models;

namespace WebExercicios.ViewModels.Output;
public class RentalOutput
{
    public int Rental_id { get; set; }
    public DateTime Rental_date { get; set; }
    public int Inventory_id { get; set; }
    public string Inventory_Film_Title { get; set; }
    public int Customer_id { get; set; }
    public string Customer_First_Name { get; set; }
    public string Customer_Last_Name { get; set; }
    public string DescricaoSituacao {get; set;}
    public TipoSituacao Situacao {get; set;}
    public DateTime Return_date { get; set; }
    public int Staff_id { get; set; }
    public DateTime Last_update { get; set; }
    public DateTime Forecast_date { get; set; }
}
