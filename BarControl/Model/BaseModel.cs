using System.ComponentModel.DataAnnotations;
namespace BarControl.Model;

public abstract class BaseModel
{
    public BaseModel()
    {
        Id = Guid.NewGuid().ToString();
    }
    
    [Required] // DataAnnotations lib
    [Display(Name = "ID")]
    public string Id { get; set; }
}