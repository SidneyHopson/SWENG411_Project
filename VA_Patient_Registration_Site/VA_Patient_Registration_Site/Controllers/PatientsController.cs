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
    public class PatientsController : Controller
    {
        private readonly VARPRContext _context;

        public PatientsController(VARPRContext context)
        {
            _context = context;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            var vARPRContext = _context.Patient.Include(p => p.User);
            return View(await vARPRContext.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Pat_id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            ViewData["Pat_id"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email, Password")] User user, [Bind("Pat_fname,Pat_lname,DOB")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                user.IsDoc = false;
                _context.User.Add(user);
                patient.Pat_id = user.Id;
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = patient.Pat_id });
            }
            ViewData["Pat_id"] = new SelectList(_context.User, "Id", "Id", patient.Pat_id);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            ViewData["Pat_id"] = new SelectList(_context.User, "Id", "Id", patient.Pat_id);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pat_id,Pat_fname,Pat_lname,DOB,Doc_id")] Patient patient)
        {
            if (id != patient.Pat_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Pat_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = patient.Pat_id});
            }
            ViewData["Pat_id"] = new SelectList(_context.User, "Id", "Id", patient.Pat_id);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Pat_id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patient.FindAsync(id);
            _context.Patient.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return _context.Patient.Any(e => e.Pat_id == id);
        }
    }
}
