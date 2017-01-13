using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoaWebsite.Web.Models;

namespace SoaWebsite.Web.Controllers
{
    public class DevelopersController : Controller
    {
        private DeveloperContext _context;

        public DevelopersController(DeveloperContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Developers.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Developer developer)
        {
            if (ModelState.IsValid)
            {
                _context.Developers.Add(developer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(developer);
        }

    }
}
