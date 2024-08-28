namespace BarControl.Model;

public class Product : BaseModel
{
    public Product()
    {
        
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public double PurchasePrice { get; set; }
    public double SellingValue { get; set; }
    
}