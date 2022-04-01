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
    public class TeamsController : Controller
    {
        private readonly LoLDbContext _context;

        public TeamsController(LoLDbContext context)
        {
            _context = context;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            var loLDbContext = _context.Teams.Include(t => t.Player1).Include(t => t.Player2).Include(t => t.Player3).Include(t => t.Player4).Include(t => t.Player5);
            return View(await loLDbContext.ToListAsync());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Include(t => t.Player1)
                .Include(t => t.Player2)
                .Include(t => t.Player3)
                .Include(t => t.Player4)
                .Include(t => t.Player5)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            ViewData["Player1Id"] = new SelectList(_context.Players, "Id", "Nickname");
            ViewData["Player2Id"] = new SelectList(_context.Players, "Id", "Nickname");
            ViewData["Player3Id"] = new SelectList(_context.Players, "Id", "Nickname");
            ViewData["Player4Id"] = new SelectList(_context.Players, "Id", "Nickname");
            ViewData["Player5Id"] = new SelectList(_context.Players, "Id", "Nickname");
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Player1Id,Player2Id,Player3Id,Player4Id,Player5Id,Id")] Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Player1Id"] = new SelectList(_context.Players, "Id", "Nickname", team.Player1Id);
            ViewData["Player2Id"] = new SelectList(_context.Players, "Id", "Nickname", team.Player2Id);
            ViewData["Player3Id"] = new SelectList(_context.Players, "Id", "Nickname", team.Player3Id);
            ViewData["Player4Id"] = new SelectList(_context.Players, "Id", "Nickname", team.Player4Id);
            ViewData["Player5Id"] = new SelectList(_context.Players, "Id", "Nickname", team.Player5Id);
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            ViewData["Player1Id"] = new SelectList(_context.Players, "Id", "Nickname", team.Player1Id);
            ViewData["Player2Id"] = new SelectList(_context.Players, "Id", "Nickname", team.Player2Id);
            ViewData["Player3Id"] = new SelectList(_context.Players, "Id", "Nickname", team.Player3Id);
            ViewData["Player4Id"] = new SelectList(_context.Players, "Id", "Nickname", team.Player4Id);
            ViewData["Player5Id"] = new SelectList(_context.Players, "Id", "Nickname", team.Player5Id);
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Player1Id,Player2Id,Player3Id,Player4Id,Player5Id,Id")] Team team)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.Id))
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
            ViewData["Player1Id"] = new SelectList(_context.Players, "Id", "Nickname", team.Player1Id);
            ViewData["Player2Id"] = new SelectList(_context.Players, "Id", "Nickname", team.Player2Id);
            ViewData["Player3Id"] = new SelectList(_context.Players, "Id", "Nickname", team.Player3Id);
            ViewData["Player4Id"] = new SelectList(_context.Players, "Id", "Nickname", team.Player4Id);
            ViewData["Player5Id"] = new SelectList(_context.Players, "Id", "Nickname", team.Player5Id);
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Include(t => t.Player1)
                .Include(t => t.Player2)
                .Include(t => t.Player3)
                .Include(t => t.Player4)
                .Include(t => t.Player5)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
