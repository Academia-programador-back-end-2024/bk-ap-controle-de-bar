using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.Model;

public class Mesa : BaseModel
{
    public Mesa() { }
    public int Numero { get; set; }
}

public class Produto : BaseModel
{
    public Produto() : base() { }

    [Required]
    [MinLength(2)]
    [MaxLength(99)]
    public string Nome { get; set; }

    [MinLength(2)]
    [MaxLength(99)]
    public string? Descricao { get; set; }

    [Required]
    public double PrecoDeCompra { get; set; }

    [Required]
    public double PrecoDeVenda { get; set; }

}