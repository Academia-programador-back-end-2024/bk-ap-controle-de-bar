namespace BarControl
{
    public class Program
    {
        public static List<Client> clients = new List<Client>();

        public static void Main(string[] args)
        {

            for (int i = 0; i < 10; i++)
            {
                Client client = new Client
                {
                    Name = "Cliente" + i.ToString() // ?
                };
                clients.Add(client);
            }

            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // Minimal api
            // Delegate
            // Pointer c++
            // Lambda expression
            app.MapGet("/clientes", GetClients);

            app.Run();
        }

        private static IResult GetClients()
        {
            string html = @"
        <!DOCTYPE html>
        <html lang='en'>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <title>Clients List</title>
            <style>
                table {
                    width: 50%;
                    border-collapse: collapse;
                    margin: 20px 0;
                }
                th, td {
                    border: 1px solid #ddd;
                    padding: 8px;
                    text-align: left;
                }
                th {
                    background-color: #f2f2f2;
                }
                tr:nth-child(even) {
                    background-color: #f9f9f9;
                }
            </style>
        </head>
        <body>
            <h2>Clients List</h2>
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                    </tr>
                </thead>
                <tbody>";

            foreach (Client client in clients)
            {
                html += $@"
                    <tr>
                        <td>{client.Id}</td>
                        <td>{client.Name}</td>
                    </tr>";
            }

            html += @"
                </tbody>
            </table>
        </body>
        </html>";

            return Results.Text(html, "text/html");
        }

        public class Client
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public Client()
            {
                Id = Guid.NewGuid();
            }
        }
    }
}
