using ControleDeBar.Model;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar
{
    public class ClientesController : Controller
    {
        public static List<Cliente> Clientes;

        private static void SemearCLientes()
        {
            if (Clientes == null)
            {
                Clientes = new List<Cliente>();
                for (int i = 0; i < 10; i++)
                {
                    Cliente cliente = new Cliente();
                    cliente.Nome = "Cliente " + i.ToString();
                    cliente.Id = i.ToString();
                    Clientes.Add(cliente);
                }
            }
        }

        public ClientesController()
        {
            SemearCLientes();
        }

        public IActionResult Index()
        {
            ViewBag.Clientes = Clientes;
            return View();
        }

        public IActionResult Detalhes(int id = 0)
        {
            Cliente cliente = Clientes.FirstOrDefault(cliente => cliente.Id == id.ToString());
            ViewBag.Cliente = cliente;
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Deletar()
        {
            return View();
        }



    }
}
