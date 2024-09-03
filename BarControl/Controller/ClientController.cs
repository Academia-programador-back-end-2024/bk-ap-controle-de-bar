using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarControl.Data;
using BarControl.Model;

namespace BarControl.Controller
{
    public class ClientController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly BarControlContext _context;
        
        private void Seed()
        {
            if (_context.Product.Any() is false)
            {
                for (int i = 0; i < 10; i++)
                {
                    Client client = new Client();
                    client.Name = $"Client {i}";
                    client.Id = i.ToString();
                    _context.Client.Add(client);
                }
            }
            _context.SaveChanges();
        }
        
        public ClientController(BarControlContext context)
        {
            _context = context;
        }
        
        // Get: Client
        public async Task<IActionResult> Index()
        {
            return View(await _context.Client.ToListAsync());
        }
        
        // Get (ById, Details)
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // Creation get
        public IActionResult Create()
        {
            return View();
        }
        // Creation post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }
        
        
        // Edit get
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();

            }
            return View(client);
        }
        // Edit post
        [HttpPost]
        public async Task<IActionResult> Edit(string id, [Bind("Id, Name")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client); // Generally, no database interaction will be performed until SaveChanges() is called, written on documentation
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }
    
        // Deletion get
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }
        
        // Deletion post
        [HttpPost, ActionName("Delete")] // noice
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var client = await _context.Client.FindAsync(id);
            if (client != null)
            {
                _context.Client.Remove(client);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(string id)
        {
            return _context.Client.Any(e => e.Id == id); // Does e stand for Entity?
        }
    }
}

















