using ControleDeBar;
using ControleDeBar.Model;

public partial class Program
{

    public static void Main(string[] args)
    {


        var builder = WebApplication.CreateBuilder(args);

        // Para permitir usar controlladores e visualizadores
        builder.Services.AddControllersWithViews();


        var app = builder.Build();

        app.UseStaticFiles();
        app.UseRouting();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Clientes}/{action=Index}/{id?}");

        //Minimal API

        //Delegate
        //POnteiro c++
        //Lambda expression 
        //app.MapGet("/", TragaClientes);
        //app.MapGet("/clientes", TragaClientes);
        //app.MapPost("/clientes", AdicionarCliente);
        //app.MapPost("/clientes/editar", EditarCliente);
        //app.MapPost("/clientes/deletar", DeletarCliente);

        app.Run();
    }

    private static IResult TragaClientes()
    {
        string clientesTabela = string.Empty;
        foreach (var cliente in ClientesController.Clientes)
        {
            string linhaCLiente = $@"
<tr>
    <td>{cliente.Id}</td>
<form method='post' action='/clientes/editar'>  
        <input type='hidden' id='id' name='id'value='{cliente.Id}'>
    <td>
        <input type='text' id='nome' name='nome' value='{cliente.Nome}'> 
    </td>   
    <td>
        <button type='submit'> Editar </button>       
    </td>

 </form>
    
    
<form method='post' action='/clientes/deletar'>  
        <input type='hidden' id='id' name='id'value='{cliente.Id}'>
    <td>
        <button type='submit'> Deletar </button>   
    </td>   

 </form>

</tr>";
            clientesTabela += linhaCLiente;
        }
        string html =
 @$"
<html>
<head>
<title>Meu Primeiro Website</title>
</head>
<body>

<!--Formulario adicionar -->
<form method='post' action='/clientes'>
    <label for='nome'> Nome: </label>
    <input type='text' id='nome' name='nome' required>
    <button type='submit'> Adicionar Cliente </button>
</form>


<h1>Clientes</h1>

<table>
  <thead>
    <tr>

        <th>Id</th>
        <th>Nome</th>
        <th>Editar</th>
        <th>Deletar</th>
    </tr>
  </thead>

 <tbody>
    {clientesTabela}
 </tbody>
</table>
</body>
</html>
";
        return Results.Text(html, "text/html");
    }

    private static IResult AdicionarCliente(HttpContext httpContext)
    {
        var form = httpContext.Request.Form;
        var nome = form["nome"].ToString();
        var id = ClientesController.Clientes.Count + 1;
        var cliente = new Cliente()
        {
            Nome = nome,
            Id = id.ToString()
        };
        ClientesController.Clientes.Add(cliente);
        return Results.Redirect("/clientes");
    }

    private static IResult EditarCliente(HttpContext httpContext)
    {
        var form = httpContext.Request.Form;
        var nome = form["nome"].ToString();
        var id = form["id"].ToString();


        Cliente? cliente = ClientesController.Clientes.FirstOrDefault(cliente => cliente.Id == id);

        if (cliente != null)
        {
            var index = ClientesController.Clientes.LastIndexOf(cliente);
            cliente.Nome = nome;
            ClientesController.Clientes[index] = cliente;
        }

        return Results.Redirect("/clientes");
    }

    private static IResult DeletarCliente(HttpContext httpContext)
    {
        var form = httpContext.Request.Form;
        var id = form["id"].ToString();
        Cliente? cliente = ClientesController.Clientes.FirstOrDefault(cliente => cliente.Id == id);

        if (cliente != null)
        {
            ClientesController.Clientes.Remove(cliente);
        }

        return Results.Redirect("/clientes");
    }
}
