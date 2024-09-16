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
            
            // DB 
            BarControlContext context = new BarControlContext();
            
            context.Seed();

            var app = builder.Build();
            
            app.UseRouting(); // Middleware, infers the route based on the created controller 
            app.UseStaticFiles();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Client}/{action=Index}/{id?}");

            app.Run();
        }

      



    }
}
