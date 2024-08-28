using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarControl.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BarControl.Controller
{
    public class ClientController : Microsoft.AspNetCore.Mvc.Controller
    {
        public static List<Client> Clients = new List<Client>();
        private static void Seed()
        {
            for (int i = 0; i < 10; i++)
            {
                Client client = new Client
                {
                    Name = "Client" + i.ToString()
                };
                Clients.Add(client);
            }
        }

        public ClientController()
        {
            if (Clients.Count == 0)
            {
                Seed();
            }
        }

        // GetAll
        public ActionResult Index()
        {
            ViewBag.clients = Clients;
            return View();
        }
        // GetAll
    
        // GetById
        public ActionResult Details(string id = "0")
        {
            Client client = Clients.Where(c => c.Id == id).FirstOrDefault();
            if (client != null)
            {
                ViewBag.Client = client;
                return View();
            }
            return RedirectToAction("Index");
        }
        // GetById

        // Adding routes 
        [HttpGet]
        public ActionResult Add()
        {
            return View(new Client());
        }

        [HttpPost]
        public ActionResult Add(Client client)
        {
            Clients.Add(client);
            return RedirectToAction("Index");
        }
        // Adding routes 
        
        // Editing routes
        [HttpGet] 
        public ActionResult Edit(string id)
        {
            Client client = Clients.Where(c => c.Id == id).FirstOrDefault();
            if (client != null)
            {
                return View(client);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid == false)
            {
                return View(client);
            }
            var existingClient = Clients.Where(c => c.Id == client.Id).FirstOrDefault();
            if (existingClient != null)
            {
                var index = Clients.IndexOf(existingClient);
                Clients[index] = client;
            }
            return RedirectToAction("Index");
        }
        // Editing routes


        [HttpPost]
        public ActionResult Delete(string id)
        {
            Client client = Clients.FirstOrDefault(c => c.Id == id);
            Clients.Remove(client);
            return RedirectToAction("Index");
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
       

    }
}