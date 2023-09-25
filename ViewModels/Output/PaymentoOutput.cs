namespace WebExercicios.ViewModels.Output;
public class PaymentOutput
{
    public int? Payment_id { get; set; }
    public int? Customer_id { get; set; }
    public int Staff_id { get; set; }
    public int Rental_id { get; set; }
    public string Rental_film_title { get; set; }
    public string Rental_customer_first_name { get; set; }
    public string Rental_customer_last_name { get; set; }
    public decimal Amount { get; set; }
    public DateTime? Payment_date { get; set; }
    public DateTime? Last_update { get; set; }

}
