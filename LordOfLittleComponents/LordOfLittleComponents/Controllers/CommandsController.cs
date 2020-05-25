using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LordOfLittleComponents.Models;

namespace LordOfLittleComponents.Controllers
{
    public class CommandsController : Controller
    {
        private readonly LordOfLittleComponentsContext _context;

        public CommandsController(LordOfLittleComponentsContext context)
        {
            _context = context;
        }

        // GET: Commands
        public async Task<IActionResult> Index()
        {
            return View(await _context.Commands.ToListAsync());
        }

        // GET: Commands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commands = await _context.Commands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commands == null)
            {
                return NotFound();
            }

            return View(commands);
        }

        // GET: Commands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Commands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ComponentName,On,Off,Status")] Commands commands)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commands);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commands);
        }

        // GET: Commands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commands = await _context.Commands.FindAsync(id);
            if (commands == null)
            {
                return NotFound();
            }
            return View(commands);
        }

        // POST: Commands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ComponentName,On,Off,Status")] Commands commands)
        {
            if (id != commands.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commands);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommandsExists(commands.Id))
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
            return View(commands);
        }

        // GET: Commands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commands = await _context.Commands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commands == null)
            {
                return NotFound();
            }

            return View(commands);
        }

        // POST: Commands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commands = await _context.Commands.FindAsync(id);
            _context.Commands.Remove(commands);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommandsExists(int id)
        {
            return _context.Commands.Any(e => e.Id == id);
        }
    }
}
