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

        private bool PokecardExists(int id)
        {
            return _context.Pokecard.Any(e => e.ID == id);
        }
    }
}
