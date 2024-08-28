﻿using Microsoft.AspNetCore.Routing.Constraints;

namespace BarControl.Model;
using System.ComponentModel.DataAnnotations;

public class Client : BaseModel
{
    [Required]
    [Display(Description = "Client name")]
    [MinLength(length: 2, ErrorMessage ="Name needs to be at least 2 characters long")]
    [MaxLength(length: 20, ErrorMessage = "Name must not exceed 20 characters!")]
    public string Name { get; set; }
}

