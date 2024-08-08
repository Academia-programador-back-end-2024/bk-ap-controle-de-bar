namespace ControleDeBar.Model;

public class Mesa
{
    public Mesa()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string Id { get; set; }
    public int Numero { get; set; }

}