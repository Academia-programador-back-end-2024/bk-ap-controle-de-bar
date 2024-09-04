namespace BarControl.Model;

public class Slip : BaseModel
{
    public Slip() : base()
    {
        
    }

    public string ClientId { get; set; }
    public virtual Client? Client { get; set; }
    
    public string TableId { get; set; }
    public virtual Table? Table { get; set; }
    
    public string WaiterId { get; set; }
    public virtual Waiter? Waiter { get; set; }
    
    public virtual  List<Consumption>? Consumptions { get; set; }
    
    public DateTime OpeningDate { get; set; }
    public DateTime? ClosingDate { get; set; }
    
    public bool Paid { get; set; } // Defaults to false
}