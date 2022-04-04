using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoL.Data;
using LoL.Models;
using LoL.ViewModels;

namespace LoL.Controllers
{
    public class GamesController : Controller
    {
        private readonly LoLDbContext _context;

        public GamesController(LoLDbContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var loLDbContext = _context.Games.Include(g => g.Composition1.Team).Include(g => g.Composition2.Team);
            return View(await loLDbContext.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.Composition1.Team)
                .Include(g => g.Composition2.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public async Task<IActionResult> CreateAsync()
        {
            return View(new GameCreationViewModel {
                Game = new Game(),
                Teams = await _context.Teams.ToListAsync(),
                Legends = await _context.Legends.ToListAsync(),
            });
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(new GameCreationViewModel {
                Game = game,
                Teams = await _context.Teams.ToListAsync(),
                Legends = await _context.Legends.ToListAsync(),
            });
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.Composition1)
                .Include(g => g.Composition1.Team)
                .Include(g => g.Composition1.Team!.Player1)
                .Include(g => g.Composition1.Team!.Player2)
                .Include(g => g.Composition1.Team!.Player3)
                .Include(g => g.Composition1.Team!.Player4)
                .Include(g => g.Composition1.Team!.Player5)
                .Include(g => g.Composition2)
                .Include(g => g.Composition2.Team)
                .Include(g => g.Composition2.Team!.Player1)
                .Include(g => g.Composition2.Team!.Player2)
                .Include(g => g.Composition2.Team!.Player3)
                .Include(g => g.Composition2.Team!.Player4)
                .Include(g => g.Composition2.Team!.Player5)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            return View(new GameCreationViewModel {
                Game = game,
                Teams = await _context.Teams.ToListAsync(),
                Legends = await _context.Legends.ToListAsync(),
            });
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
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

            return View(new GameCreationViewModel {
                Game = game,
                Teams = await _context.Teams.ToListAsync(),
                Legends = await _context.Legends.ToListAsync(),
            });
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.Composition1)
                .Include(g => g.Composition2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game is null)
                return NotFound();

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
