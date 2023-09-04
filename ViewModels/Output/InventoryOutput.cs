namespace WebExercicios.ViewModels.Output;
public class InventoryOutput
{
    public int Inventory_id { get; set; }
    public int Film_id { get; set; }
    public string Film_Name { get; set; }
    public int Store_id { get; set; }
    public string Story_Address { get; set;}
    public string Story_City { get; set;}
    public DateTime Last_update { get; set; }
}
