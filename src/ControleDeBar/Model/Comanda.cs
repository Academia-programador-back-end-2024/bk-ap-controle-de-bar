using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.Model;

public class Comanda : BaseModel
{
    public Comanda() : base()
    {

    }

    [Display(Name = "Data de Abertura")]
    public DateTime DataDeAbertura { get; set; }

    [Display(Name = "Data de Encerramento")]
    public DateTime? DataDeEncerramento { get; set; }

    public bool? Pago { get; set; }


    public string ClienteId { get; set; }
    [Display(Name = "Nome do cliente")]
    public virtual Cliente? Cliente { get; set; }

    public string MesaId { get; set; }
    [Display(Name = "Numero da mesa")]
    public virtual Mesa? Mesa { get; set; }

    public string GarcomId { get; set; }
    [Display(Name = "Nome do Garçom")]
    public virtual Garcom? Garcom { get; set; }

    public virtual List<Consumo>? Consumos { get; set; }


    public double TotalCusto()
    {
        double totalCusto = 0.0;

        foreach (Consumo consumo in Consumos)
        {
            totalCusto += consumo.Quantidade * consumo.Produto.PrecoDeCompra;
        }
        return totalCusto;
    }

    public double TotalVenda()
    {
        double totalVenda = 0.0;

        Consumos.ForEach(consumo => totalVenda += consumo.Quantidade * consumo.Produto.PrecoDeVenda);

        return totalVenda;
    }


}

public class ComandaFiltro
{
    public ComandaFiltro()
    {
        DataInicio = DateTime.Now.AddDays((-1));
        DataFim = DateTime.Now;
        TermoBusca = string.Empty;
        Pago = false;
    }

    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public string? TermoBusca { get; set; }

    public bool? Pago { get; set; }

}