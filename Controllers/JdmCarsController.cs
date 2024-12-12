using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRecommenderIA.Models;
using CarrecomenderIA.Data;

namespace CarRecommenderIA.Controllers
{
    public class JdmCarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JdmCarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JdmCars
        public async Task<IActionResult> Index()
        {
            return View(await _context.JdmCars.ToListAsync());
        }

        // GET: JdmCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jdmCar = await _context.JdmCars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jdmCar == null)
            {
                return NotFound();
            }

            return View(jdmCar);
        }

        // GET: JdmCars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JdmCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Year,Make,Model,Engine,Num_Of_Cyl,Aspiration,Horsepower,Torque,Top_Speed,Drive_Type,Curb_Weight,Fuel_Type,Transmission,Fuel_Economy_MPG,Price_USD")] JdmCar jdmCar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jdmCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jdmCar);
        }

        // GET: JdmCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jdmCar = await _context.JdmCars.FindAsync(id);
            if (jdmCar == null)
            {
                return NotFound();
            }
            return View(jdmCar);
        }

        // POST: JdmCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Year,Make,Model,Engine,Num_Of_Cyl,Aspiration,Horsepower,Torque,Top_Speed,Drive_Type,Curb_Weight,Fuel_Type,Transmission,Fuel_Economy_MPG,Price_USD")] JdmCar jdmCar)
        {
            if (id != jdmCar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jdmCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JdmCarExists(jdmCar.Id))
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
            return View(jdmCar);
        }

        // GET: JdmCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jdmCar = await _context.JdmCars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jdmCar == null)
            {
                return NotFound();
            }

            return View(jdmCar);
        }

        // POST: JdmCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jdmCar = await _context.JdmCars.FindAsync(id);
            if (jdmCar != null)
            {
                _context.JdmCars.Remove(jdmCar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JdmCarExists(int id)
        {
            return _context.JdmCars.Any(e => e.Id == id);
        }
    }
}
