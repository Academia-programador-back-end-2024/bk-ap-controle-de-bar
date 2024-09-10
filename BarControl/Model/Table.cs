namespace BarControl.Model;
using System.ComponentModel.DataAnnotations;

public class Table : BaseModel
{
    public Table()
    {
        
    }
    
    
    [Required]
    [Display(Description = "Table number", Name = "Table number")]
    public int Number { get; set; }
    
    
}

