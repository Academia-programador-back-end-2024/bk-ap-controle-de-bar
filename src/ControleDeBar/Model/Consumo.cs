namespace ControleDeBar.Model;

public class Consumo : BaseModel
{
    public Consumo() : base()
    {
        Quantidade = 1;
    }
    public int Quantidade { get; set; }


    public string ProdutoId { get; set; }
    public virtual Produto Produto { get; set; }

    public string ComandaId { get; set; }
    public virtual Comanda Comanda { get; set; }

}