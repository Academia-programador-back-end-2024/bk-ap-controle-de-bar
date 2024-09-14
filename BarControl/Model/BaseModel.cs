namespace BarControl.Model;
using BarControl.Data;

public abstract class BaseModel
{
    private readonly BarControlContext _context;
    public BaseModel()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    public string Id { get; set; }


    private string IsRelatedToSlip()
    {
        string errorMessage = string.Empty;
        
        return errorMessage;
    }
}