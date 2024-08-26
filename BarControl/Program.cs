using BarControl.Model;
namespace BarControl

{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews(); // Allows Controllers and Views to be used

            var app = builder.Build();

            app.UseRouting(); // Middleware, infers the route based on the created controller 
            
            // GetAll
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Clients}/{action=Index}/{id?}");
            //
            
                

            app.Run();
        }

        private static IResult AddClient(HttpContext httpContext)
        {
            var form = httpContext.Request.Form;
            var name = form["name"].ToString();
            var id = ClientsController.Clients.Count + 1;
            var client = new Client();
            client.Name = name;
            client.Id = id;
            ClientsController.Clients.Add(client);
            return Results.Redirect("/clients");
        }

        private static IResult EditClient(HttpContext httpContext)
        {
            var form = httpContext.Request.Form;
            var name = form["name"].ToString();
            var id = form["id"];

            Client? client = ClientsController.Clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
            {
                client.Name = name;
            }

            return Results.Redirect("/clients");
        }

        private static IResult DeleteClient(HttpContext httpContext)
        {
            var form = httpContext.Request.Form;
            var id = form["id"];
            Client? client = ClientsController.Clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
            {
                ClientsController.Clients.Remove(client);
            }

            return Results.Redirect("/clients");
        }




    }
}
