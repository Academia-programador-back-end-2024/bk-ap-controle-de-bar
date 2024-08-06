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
    [MinLength(length: 2)]
    [MaxLength(length: 99)]
    public string Nome { get; set; }

}

