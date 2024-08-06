using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.Model;
public class Cliente
{
    public Cliente()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }

    [Required]
    [Display(Description = "Nome cliente")]
    [MinLength(length: 2, ErrorMessage = "Minimo de dois caracteres")]
    [MaxLength(length: 99, ErrorMessage = "Maximo de noventa e nove caracteres")]
    public string Nome { get; set; }

}

