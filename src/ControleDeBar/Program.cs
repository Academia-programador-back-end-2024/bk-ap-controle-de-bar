using ControleDeBar.Data;

public partial class Program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Para permitir usar controlladores e visualizadores
        builder.Services.AddControllersWithViews();

        //Injeção de serviços para quem precisa da entidade de contexto de dados
        builder.Services.AddDbContext<ControleDeBarContext>();

        ControleDeBarContext contexto = new ControleDeBarContext();

        contexto.Semear();

        var app = builder.Build();

        app.UseStaticFiles();
        app.UseRouting();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Clientes}/{action=Index}/{id?}");

        app.Run();
    }


}
