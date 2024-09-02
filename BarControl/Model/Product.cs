using System.ComponentModel.DataAnnotations;

namespace BarControl.Model;

public class Product : BaseModel
{
    public Product() : base()
    {
        
    }
    [Required]
    [Display(Name = "Product name")]
    public string Name { get; set; }
    
    [Required]
    [Display(Name = "Product description")]
    public string? Description { get; set; }
    
    [Required]
    [Display(Name = "Product purchase price")]
    public double PurchasePrice { get; set; }
    
    [Required]
    [Display(Name = "Selling value")]
    public double SellingValue { get; set; }
    
}