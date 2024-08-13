using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.Model;

public class Produto : BaseModel
{
    public Produto() : base() { }

    [Required]
    [MinLength(2)]
    [MaxLength(99)]
    public string Nome { get; set; }

    [MinLength(2)]
    [MaxLength(99)]
    [Display(Name = "Descrição")]
    public string? Descricao { get; set; }

    [Required]
    [Display(Name = "Preço de compra")]
    public double PrecoDeCompra { get; set; }

    [Required]
    [Display(Name = "Preço de venda")]
    public double PrecoDeVenda { get; set; }

}