using System.ComponentModel.DataAnnotations;
using BarControl.Data;

namespace BarControl.Model;

public class Client : BaseModel
{
    private BarControlContext _context;
    public Client() : base()
    {
        
    }
    [Required]
    [Display(Description = "Client name")]
    [MinLength(length: 2, ErrorMessage ="Name needs to be at least 2 characters long")]
    [MaxLength(length: 20, ErrorMessage = "Name must not exceed 20 characters!")]
    public string Name { get; set; }
    
   
}

