using BarControl.Data; // EF
namespace BarControl

{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews(); // Allows Controllers and Views to be used
            builder.Services.AddDbContext<BarControlContext>();

            var app = builder.Build();

            app.UseRouting(); // Middleware, infers the route based on the created controller 
            
            
            // Bootstrap
            app.UseStaticFiles();
            
            // GetAll
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Client}/{action=Index}/{id?}");
            
                

            app.Run();
        }

      



    }
}
