using System.ComponentModel.DataAnnotations;
namespace BarControl.Model;

public class Waiter : BaseModel
{
    public Waiter() : base()
    {
    }
    
    [Required]
    [Display(Description = "Waiter name")]
    [MinLength(length: 2, ErrorMessage ="Name needs to be at least 2 characters long")]
    [MaxLength(length: 20, ErrorMessage = "Name must not exceed 20 characters!")]
    public string Name { get; set; }
    
    [Required]
    [Display(Name= "Age", Description = "Waiter's age")]
    public int Age { get; set; }
}