namespace WebExercicios.ViewModels.Output;
public class CustomerOutput
{
    public int Customer_id { get; set; }
    public int Store_id { get; set; }
    public string First_name { get; set; }
    public string Last_name { get; set; }
    public string Email { get; set; }
    public int Address_id { get; set; }
    public string Customer_Address { get; set; }
    public string Customer_Address_City { get; set; }
    public int Active { get; set; }
    public DateTime Create_date { get; set; }
    public DateTime Last_update { get; set; }
}
