using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCG_CollectionGame.Data;
using TCG_CollectionGame.Models;

namespace TCG_CollectionGame.Controllers
{
    public class PokecardsController : Controller
    {
        private readonly TCG_CollectionGameContext _context;

        public PokecardsController(TCG_CollectionGameContext context)
        {
            _context = context;
        }

        // GET: Pokecards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pokecard.ToListAsync());
        }

        // GET: Pokecards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokecard = await _context.Pokecard
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pokecard == null)
            {
                return NotFound();
            }

            return View(pokecard);
        }

        // GET: Pokecards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pokecards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserId,SetCode,CardCode")] Pokecard pokecard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pokecard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pokecard);
        }

        // GET: Pokecards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokecard = await _context.Pokecard.FindAsync(id);
            if (pokecard == null)
            {
                return NotFound();
            }
            return View(pokecard);
        }

        // POST: Pokecards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserId,SetCode,CardCode")] Pokecard pokecard)
        {
            if (id != pokecard.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokecard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokecardExists(pokecard.ID))
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
            return View(pokecard);
        }

        // GET: Pokecards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokecard = await _context.Pokecard
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pokecard == null)
            {
                return NotFound();
            }

            return View(pokecard);
        }

        // POST: Pokecards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokecard = await _context.Pokecard.FindAsync(id);
            _context.Pokecard.Remove(pokecard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokecardExists(int id)
        {
            return _context.Pokecard.Any(e => e.ID == id);
        }
    }
}
