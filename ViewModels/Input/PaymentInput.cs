namespace WebExercicios.ViewModels.Input;
public class PaymentInput
{
    public int Payment_id { get; set; }
    public int Customer_id { get; set; }
    public int Staff_id { get; set; }
    public int Rental_id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Payment_date { get; set; }
    public DateTime Last_update { get; set; }
}
