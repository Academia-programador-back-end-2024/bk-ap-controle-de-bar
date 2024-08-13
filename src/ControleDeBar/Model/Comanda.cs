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


}