using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCG_CollectionGame.Data;
using TCG_CollectionGame.Models;

namespace TCG_CollectionGame.Controllers
{
    public class UsersController : Controller
    {
        private readonly TCG_CollectionGameContext _context;

        public UsersController(TCG_CollectionGameContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Check([Bind("ID,Username,Password,Coin")] User user)
        {
            User u = _context.User.FirstOrDefault(e => e.Username == user.Username);
            if (BCrypt.Net.BCrypt.Verify(user.Password, u.Password))
            {
                return RedirectToAction("index", "Home");
            }

            return RedirectToAction("index", "Login");
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Username,Password,Coin")] User user)
        {
            if (ModelState.IsValid)
            {
                string hashed = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.Password = hashed;

                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("index", "Login");
            }
            return RedirectToAction("index", "Login");
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Username,Password,Coin")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
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
            return View(user);
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.ID == id);
        }
    }
}
