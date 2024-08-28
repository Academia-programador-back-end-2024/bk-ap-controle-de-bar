
namespace BarControl.Model;
using System.ComponentModel.DataAnnotations;

public class Table : BaseModel
{
    public Table() : base()
    {
        
    }
    
    [Required]
    [Display(Description = "Table number")]
    public int Number { get; set; }
}
