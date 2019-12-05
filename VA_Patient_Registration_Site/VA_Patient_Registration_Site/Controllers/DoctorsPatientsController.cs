using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VA_Patient_Registration_Site.Models;

namespace VA_Patient_Registration_Site.Controllers
{
    public class DoctorsPatientsController : Controller
    {
        private readonly VARPRContext _context;

        public DoctorsPatientsController(VARPRContext context)
        {
            _context = context;
        }

        // GET: DoctorsPatients
        public async Task<IActionResult> Index()
        {
            return View(await _context.DoctorsPatients.ToListAsync());
        }

        // GET: DoctorsPatients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorsPatients = await _context.DoctorsPatients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorsPatients == null)
            {
                return NotFound();
            }

            return View(doctorsPatients);
        }

        // GET: DoctorsPatients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorsPatients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Doc_id")] DoctorsPatients doctorsPatients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorsPatients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorsPatients);
        }

        // GET: DoctorsPatients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorsPatients = await _context.DoctorsPatients.FindAsync(id);
            if (doctorsPatients == null)
            {
                return NotFound();
            }
            return View(doctorsPatients);
        }

        // POST: DoctorsPatients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Doc_id")] DoctorsPatients doctorsPatients)
        {
            if (id != doctorsPatients.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorsPatients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorsPatientsExists(doctorsPatients.Id))
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
            return View(doctorsPatients);
        }

        // GET: DoctorsPatients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorsPatients = await _context.DoctorsPatients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorsPatients == null)
            {
                return NotFound();
            }

            return View(doctorsPatients);
        }

        // POST: DoctorsPatients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorsPatients = await _context.DoctorsPatients.FindAsync(id);
            _context.DoctorsPatients.Remove(doctorsPatients);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorsPatientsExists(int id)
        {
            return _context.DoctorsPatients.Any(e => e.Id == id);
        }
    }
}
