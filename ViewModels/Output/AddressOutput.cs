namespace WebExercicios.ViewModels.Output;
public class AddressOutput
{
    public int Address_id { get; set; }
    public string District { get; set; }
    public string Address { get; set; }
    public string? Address2 { get; set; }
    public int Phone { get; set; }
    public int? Postal_code { get; set; }
    public DateTime Last_update { get; set; }
    public int City_id { get; set; }
    public string City_Name { get; set; }

}
