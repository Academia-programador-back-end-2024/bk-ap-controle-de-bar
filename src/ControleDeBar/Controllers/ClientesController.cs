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
            return View(Clientes);
        }

        public IActionResult Detalhes(int id = 0)
        {
            Cliente cliente = Clientes.FirstOrDefault(cliente => cliente.Id == id.ToString());
            ViewBag.Cliente = cliente;
            return View();
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            ViewBag.Error = string.Empty;
            return View(new Cliente());
        }

        [HttpPost]
        public IActionResult Adicionar(Cliente cliente)
        {
            bool existeCliente = false;

            existeCliente = Clientes.Exists(clienteLista => clienteLista.Nome.Equals(cliente.Nome));

            if (existeCliente)
            {
                ViewBag.Error = "Já Existe esse cliente";
            }
            else
            {
                ViewBag.Error = string.Empty;
                Clientes.Add(cliente);
            }

            return View(cliente);
        }


        public IActionResult Editar(int id = 0)
        {
            Cliente cliente = Clientes.FirstOrDefault(cliente => cliente.Id == id.ToString());
            ViewBag.Index = Clientes.LastIndexOf(cliente);
            ViewBag.Error = string.Empty;
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente, int index)
        {
            bool existeCliente = false;

            existeCliente = Clientes.Exists(clienteLista => clienteLista.Nome.Equals(cliente.Nome));
            ViewBag.Index = index;
            if (existeCliente)
            {
                ViewBag.Error = "Já existe cliente com esse nome";
            }
            else
            {
                Clientes[index] = cliente;
            }
            return View(cliente);
        }


        public IActionResult Deletar(int id = 0)
        {
            Cliente cliente = Clientes.FirstOrDefault(cliente => cliente.Id == id.ToString());
            ViewBag.Index = Clientes.LastIndexOf(cliente);
            ViewBag.Error = string.Empty;
            ViewBag.DeleteSucesso = false;
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Deletar(Cliente cliente, int index)
        {
            ViewBag.Index = index;
            ViewBag.DeleteSucesso = false;
            try
            {
                Cliente confirmarCliente = Clientes[index];
                if (confirmarCliente.Id == cliente.Id)
                {

                    Clientes.RemoveAt(index);
                    ViewBag.DeleteSucesso = true;
                }
                else
                {
                    ViewBag.Error = "Cliente não confirmado, revise os dados.";
                }
            }
            catch
            {
                ViewBag.Error = "Cliente não confirmado, revise os dados.";
            }

            return View(cliente);
        }



    }
}
