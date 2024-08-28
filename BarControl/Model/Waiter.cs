using Microsoft.AspNetCore.Routing.Constraints;

namespace BarControl.Model;
using System.ComponentModel.DataAnnotations;

public class Waiter : BaseModel
{
    public Waiter() : base()
    {
        Id = Guid.NewGuid().ToString();
        Age = 18;
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