namespace BarControl.Model;
using BarControl.Data;

public abstract class BaseModel
{
    public BaseModel()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    public string Id { get; set; }

}