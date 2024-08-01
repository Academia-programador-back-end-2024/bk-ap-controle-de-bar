namespace ControleDeBar.Model;
public class Cliente
{
    public Cliente()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
    public string Nome { get; set; }

}

