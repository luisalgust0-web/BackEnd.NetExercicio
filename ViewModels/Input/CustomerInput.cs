using System.ComponentModel.DataAnnotations;

namespace WebExercicios.ViewModels.Input;
public class CustomerInput
{
    public int Customer_id { get; set; }
    public int Store_id { get; set; }
    [MaxLength(45)]
    public string First_name { get; set; }
    [MaxLength(45)]
    public string Last_name { get; set; }
    [MaxLength(50)]
    [EmailAddress]
    public string Email { get; set; }
    public int Address_id { get; set; }
    [Range(0,1, ErrorMessage = "Active só aceita 0 e 1")]
    public int Active { get; set; }
    public DateTime Create_date { get; set; }
    public DateTime Last_update { get; set; }
}
