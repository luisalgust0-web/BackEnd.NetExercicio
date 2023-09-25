namespace WebExercicios.ViewModels.Output;
public class StoreOutput
{
    public int Store_id { get; set; }
    public int Address_id {get;set;}
    public string Store_Address { get; set; }
    public string Store_Address_City { get; set; }
    public int Manager_staff_id {get;set;}
    public string Manager_staff_First_Name { get; set; }
    public string Manager_staff_Last_Name { get; set; }
    public DateTime Last_update {get;set;}
}
