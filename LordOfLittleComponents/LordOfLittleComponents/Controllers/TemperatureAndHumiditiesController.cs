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
    public class TemperatureAndHumiditiesController : Controller
    {
        private readonly LordOfLittleComponentsContext _context;

        public TemperatureAndHumiditiesController(LordOfLittleComponentsContext context)
        {
            _context = context;
        }

        // GET: TemperatureAndHumidities
        public async Task<IActionResult> Index()
        {
            return View(await _context.TemperatureAndHumidity.ToListAsync());
        }

        // GET: TemperatureAndHumidities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperatureAndHumidity = await _context.TemperatureAndHumidity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temperatureAndHumidity == null)
            {
                return NotFound();
            }

            return View(temperatureAndHumidity);
        }

        // GET: TemperatureAndHumidities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TemperatureAndHumidities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Temperature,Humidity")] TemperatureAndHumidity temperatureAndHumidity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temperatureAndHumidity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(temperatureAndHumidity);
        }

        // GET: TemperatureAndHumidities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperatureAndHumidity = await _context.TemperatureAndHumidity.FindAsync(id);
            if (temperatureAndHumidity == null)
            {
                return NotFound();
            }
            return View(temperatureAndHumidity);
        }

        // POST: TemperatureAndHumidities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Temperature,Humidity")] TemperatureAndHumidity temperatureAndHumidity)
        {
            if (id != temperatureAndHumidity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temperatureAndHumidity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemperatureAndHumidityExists(temperatureAndHumidity.Id))
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
            return View(temperatureAndHumidity);
        }

        // GET: TemperatureAndHumidities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperatureAndHumidity = await _context.TemperatureAndHumidity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temperatureAndHumidity == null)
            {
                return NotFound();
            }

            return View(temperatureAndHumidity);
        }

        // POST: TemperatureAndHumidities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temperatureAndHumidity = await _context.TemperatureAndHumidity.FindAsync(id);
            _context.TemperatureAndHumidity.Remove(temperatureAndHumidity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemperatureAndHumidityExists(int id)
        {
            return _context.TemperatureAndHumidity.Any(e => e.Id == id);
        }
    }
}
