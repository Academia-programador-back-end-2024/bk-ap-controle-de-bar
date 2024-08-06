using ControleDeBar.Data;

public partial class Program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Para permitir usar controlladores e visualizadores
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<ControleDeBarContext>();

        var app = builder.Build();

        app.UseStaticFiles();
        app.UseRouting();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Clientes}/{action=Index}/{id?}");

        app.Run();
    }


}
