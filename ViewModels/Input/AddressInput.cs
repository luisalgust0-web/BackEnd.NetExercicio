using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace WebExercicios.ViewModels.Input;
public class AddressInput
{
    public int? Address_id { get; set; }
    [MaxLength(20,ErrorMessage = "District > 20")]
    public string District { get; set; }
    public string Address { get; set; }
    public string? Address2 { get; set; }
    [MaxLength(20,ErrorMessage = "Phone > 20")]
    public string Phone { get; set; }
    [MaxLength(10,ErrorMessage = "Postal_code > 10")]
    public string? Postal_code { get; set; }
    public DateTime Last_update { get; set; }
    public int City_id { get; set; }
}
