namespace BarControl.Model;

public class BillingViewModel
{
    public List<Slip>Slips { get; set; }
    // Everything that has been paid
    public double BillTotal {get;set;}
    public double PendentTotal { get; set; }
    
    // Sum of all slips
    public double TotalCostSlips { get; set; }

    public double TotalProfit { get; set; }
    
    public double DailyBilled { get; set; }
    
    
}