using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Models;
using Portfolio2.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio2.Controllers
{
    public class HomeController : Controller
    {
        myContext db;
        public HomeController (myContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            
             List<PortfolioItem> items= db.PortfolioItems.Where(x => x.OwnerId == 1).ToList();
            ViewData["items"] = items;
             

            /*
            var homeViewModel = new HomeViewModel
            {
                Owner = db.Owners.Find(1),
                PortfolioItems = db.PortfolioItems.Where(x => x.OwnerId == 1).ToList()

            };
            */
            return View();
        }

        
        [HttpPost]
        public IActionResult SaveContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
