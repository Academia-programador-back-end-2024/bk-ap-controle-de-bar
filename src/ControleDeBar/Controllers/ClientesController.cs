using ControleDeBar.Data;
using ControleDeBar.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar
{
    public class ClientesController : Controller
    {
        private readonly ControleDeBarContext _context;

        public ClientesController(ControleDeBarContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Clientes.ToList());
        }

        public IActionResult Detalhes(int id = 0)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id.ToString());
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

            existeCliente = _context.Clientes.Any(clienteLista => clienteLista.Nome.Equals(cliente.Nome));

            if (existeCliente)
            {
                ViewBag.Error = "Já Existe esse cliente";
            }
            else
            {
                ViewBag.Error = string.Empty;
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }

            return View(cliente);
        }


        public IActionResult Editar(string id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id.ToString());
            ViewBag.Index = cliente.Id;
            ViewBag.Error = string.Empty;
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente, string index)
        {
            if (ModelState.IsValid == false)
            {
                return View(cliente);
            }

            bool existeCliente = false;

            existeCliente = _context.Clientes.Any(clienteLista => clienteLista.Nome.Equals(cliente.Nome));
            ViewBag.Index = index;
            if (existeCliente)
            {
                ViewBag.Error = "Já existe cliente com esse nome";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(cliente);
                        _context.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(cliente);
        }


        public IActionResult Deletar(string id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            ViewBag.Index = cliente.Id;
            ViewBag.Error = string.Empty;
            ViewBag.DeleteSucesso = false;
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Deletar(Cliente cliente, string index)
        {
            ViewBag.Index = index;
            ViewBag.DeleteSucesso = false;
            try
            {
                Cliente confirmarCliente =
                    _context.Clientes.FirstOrDefault(cliente => cliente.Id.Equals(index));
                if (confirmarCliente != null)
                {
                    _context.Remove(confirmarCliente);
                    _context.SaveChanges();
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
