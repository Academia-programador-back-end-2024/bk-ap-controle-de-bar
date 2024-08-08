using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.Model;

public class Garcom : BaseModel
{
    public Garcom() : base() { }

    [Required]
    [MinLength(length: 2, ErrorMessage = "Minimo de dois caracteres")]
    [MaxLength(length: 99, ErrorMessage = "Maximo de noventa e nove caracteres")]
    public string Nome { get; set; }

}