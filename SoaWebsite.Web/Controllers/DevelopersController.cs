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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developer = await _context.Developers.SingleOrDefaultAsync(m => m.ID == id);
            if (developer == null)
            {
                return NotFound();
            }
            return View(developer);
        }

        // POST: Developers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName")] Developer developer)
        {
            if (id != developer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(developer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeveloperExists(developer.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(developer);
        }

        private bool DeveloperExists(int id)
        {
            return _context.Developers.Any(e => e.ID == id);
        }
    }
}
