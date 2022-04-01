#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoL.Data;
using LoL.Models;

namespace LoL.Controllers
{
    public class LegendsController : Controller
    {
        private readonly LoLDbContext _context;

        public LegendsController(LoLDbContext context)
        {
            _context = context;
        }

        // GET: Legends
        public async Task<IActionResult> Index()
        {
            return View(await _context.Legends.ToListAsync());
        }

        // GET: Legends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legend = await _context.Legends
                .FirstOrDefaultAsync(m => m.Id == id);
            if (legend == null)
            {
                return NotFound();
            }

            return View(legend);
        }

        // GET: Legends/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Legends/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Category,Bio")] Legend legend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(legend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(legend);
        }

        // GET: Legends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legend = await _context.Legends.FindAsync(id);
            if (legend == null)
            {
                return NotFound();
            }
            return View(legend);
        }

        // POST: Legends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Category,Bio")] Legend legend)
        {
            if (id != legend.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(legend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LegendExists(legend.Id))
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
            return View(legend);
        }

        // GET: Legends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legend = await _context.Legends
                .FirstOrDefaultAsync(m => m.Id == id);
            if (legend == null)
            {
                return NotFound();
            }

            return View(legend);
        }

        // POST: Legends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var legend = await _context.Legends.FindAsync(id);
            _context.Legends.Remove(legend);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LegendExists(int id)
        {
            return _context.Legends.Any(e => e.Id == id);
        }
    }
}
