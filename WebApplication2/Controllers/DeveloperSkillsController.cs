using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DeveloperSkillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeveloperSkillsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: DeveloperSkills
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeveloperSkill.ToListAsync());
        }

        // GET: DeveloperSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developerSkill = await _context.DeveloperSkill.SingleOrDefaultAsync(m => m.ID == id);
            if (developerSkill == null)
            {
                return NotFound();
            }

            return View(developerSkill);
        }

        // GET: DeveloperSkills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeveloperSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Skill")] DeveloperSkill developerSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(developerSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(developerSkill);
        }

        // GET: DeveloperSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developerSkill = await _context.DeveloperSkill.SingleOrDefaultAsync(m => m.ID == id);
            if (developerSkill == null)
            {
                return NotFound();
            }
            return View(developerSkill);
        }

        // POST: DeveloperSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Skill")] DeveloperSkill developerSkill)
        {
            if (id != developerSkill.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(developerSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeveloperSkillExists(developerSkill.ID))
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
            return View(developerSkill);
        }

        // GET: DeveloperSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var developerSkill = await _context.DeveloperSkill.SingleOrDefaultAsync(m => m.ID == id);
            if (developerSkill == null)
            {
                return NotFound();
            }

            return View(developerSkill);
        }

        // POST: DeveloperSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var developerSkill = await _context.DeveloperSkill.SingleOrDefaultAsync(m => m.ID == id);
            _context.DeveloperSkill.Remove(developerSkill);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DeveloperSkillExists(int id)
        {
            return _context.DeveloperSkill.Any(e => e.ID == id);
        }
    }
}
