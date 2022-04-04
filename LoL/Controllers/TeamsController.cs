using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoL.Data;
using LoL.Models;
using LoL.ViewModel;

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
            return View(new TeamCreationViewModel() { Players = GetFreePlayers() });
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
            return View(new TeamCreationViewModel() { Players = GetFreePlayers(), Team = team });
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

            return View(new TeamCreationViewModel() { Players = GetFreePlayersOrInTeam((int)id), Team = team });
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

            return View(new TeamCreationViewModel() { Players = GetFreePlayersOrInTeam((int)id), Team = team });
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
            if (team is null)
                return NotFound();

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }

        private IEnumerable<Player> GetFreePlayers()
        {
            return _context.Players.FromSqlRaw(@"SELECT TOP (1000) p.[Id]
      ,p.[Name]
      ,[Surname]
      ,[Nickname]
      ,[Nationality]
      ,[Category]
      ,[Birthday]
  FROM [LoL].[dbo].[Players] p
  LEFT OUTER JOIN [Teams] t on p.Id in (t.Player1Id, t.Player2Id, t.Player3Id, t.Player4Id, t.Player5Id)
  WHERE t.Id is null");
        }

        private IEnumerable<Player> GetFreePlayersOrInTeam(int teamId)
        {
            return _context.Players.FromSqlRaw(@"SELECT TOP (1000) p.[Id]
      ,p.[Name]
      ,[Surname]
      ,[Nickname]
      ,[Nationality]
      ,[Category]
      ,[Birthday]
  FROM [LoL].[dbo].[Players] p
  LEFT OUTER JOIN [Teams] t on p.Id in (t.Player1Id, t.Player2Id, t.Player3Id, t.Player4Id, t.Player5Id)
  WHERE t.Id is null OR t.Id = {0}", teamId);
        }
    }
}
