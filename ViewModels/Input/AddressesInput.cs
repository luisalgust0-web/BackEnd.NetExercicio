using System.Drawing;

namespace WebExercicios.ViewModels.Input;
public class AddressesInput
{
    public int Address_id { get; set; }
    public string Address { get; set; }
    public string Address2 { get; set; }
    public string District { get; set; }
    public int City_id { get; set; }
    public string Postal_code { get; set; }
    public string Phone { get; set; }
    public DateTime Last_update { get; set; }
}
