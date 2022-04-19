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
using TCG_CollectionGame.Data.Interfaces;
using TCG_CollectionGame.Models;

namespace TCG_CollectionGame.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Check([Bind("ID,Username,Password,Coin")] User user)
        {
            var u = _userService.GetUser(user.Username);
            if (u == null)
            {
                TempData["ErrorMessage"] = "Username or password is incorrect";
                return RedirectToAction("index", "Login");
            }
            else if (BCrypt.Net.BCrypt.Verify(user.Password, u.Password))
            {
                TempData["userID"] = u.ID;
                TempData["username"] = u.Username;
                return RedirectToAction("index", "Home");
            }
            TempData["ErrorMessage"] = "Username or password is incorrect";
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
                if (_userService.UserExists(user.Username))
                {
                    TempData["ErrorMessage"] = "This Username is already taken";
                    return RedirectToAction("Register", "Login");
                }
                else
                {
                    string hashed = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    user.Password = hashed;

                    _userService.AddUser(user);
                    TempData["ErrorMessage"] = "Successfully created your acount";
                    return RedirectToAction("index", "Login");
                }
            }
            TempData["ErrorMessage"] = "Register failed";
            return RedirectToAction("Register", "Login");
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Username,Password,Coin")] User user)
        //{
        //    if (id != user.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(user);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!userManager.UserExists(user.Username))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(user);
        //}
    }
}