using System.ComponentModel.DataAnnotations;

namespace BarControl.Model;

public class Slip : BaseModel
{
    public Slip() : base()
    {
        
    }

    public string ClientId { get; set; }
    [Display(Name = "Client name")]
    public virtual Client? Client { get; set; }
    
    public string TableId { get; set; }
    [Display(Name = "Table number")]
    public virtual Table? Table { get; set; }
    
    public string WaiterId { get; set; }
    [Display(Name = "Waiter name")]
    public virtual Waiter? Waiter { get; set; }
    
    public virtual  List<Consumption>? Consumptions { get; set; }
    
    [Display(Name = "Opening date")]
    public DateTime OpeningDate { get; set; }
    [Display(Name = "Closing date")]
    public DateTime? ClosingDate { get; set; }
    
    public bool Paid { get; set; } // Defaults to false
}