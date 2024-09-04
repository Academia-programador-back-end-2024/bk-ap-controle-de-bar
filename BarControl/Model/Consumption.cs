namespace BarControl.Model;

public class Consumption : BaseModel
{
    public Consumption() : base()
    {
        
    }

    public string ProductId { get; set; }
    // We have a DbSet for this model, for this entity so we can relate the two
    // Virtual indicates that this property is not part of this class, he is here because he is related to the class.  
    public virtual Product Product { get; set; } 
    public int Amount { get; set; }
    public string SlipId { get; set; }
    public virtual Slip Slip { get; set; }
}
