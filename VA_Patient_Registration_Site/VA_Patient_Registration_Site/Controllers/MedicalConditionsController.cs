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
    public class MedicalConditionsController : Controller
    {
        private readonly VARPRContext _context;

        public MedicalConditionsController(VARPRContext context)
        {
            _context = context;
        }

        // GET: MedicalConditions
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicalCondition.ToListAsync());
        }

        // GET: MedicalConditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalCondition = await _context.MedicalCondition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalCondition == null)
            {
                return NotFound();
            }

            return View(medicalCondition);
        }

        // GET: MedicalConditions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicalConditions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DiagnosisDate,Notes")] MedicalCondition medicalCondition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalCondition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicalCondition);
        }

        // GET: MedicalConditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalCondition = await _context.MedicalCondition.FindAsync(id);
            if (medicalCondition == null)
            {
                return NotFound();
            }
            return View(medicalCondition);
        }

        // POST: MedicalConditions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DiagnosisDate,Notes")] MedicalCondition medicalCondition)
        {
            if (id != medicalCondition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalCondition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalConditionExists(medicalCondition.Id))
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
            return View(medicalCondition);
        }

        // GET: MedicalConditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalCondition = await _context.MedicalCondition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalCondition == null)
            {
                return NotFound();
            }

            return View(medicalCondition);
        }

        // POST: MedicalConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalCondition = await _context.MedicalCondition.FindAsync(id);
            _context.MedicalCondition.Remove(medicalCondition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalConditionExists(int id)
        {
            return _context.MedicalCondition.Any(e => e.Id == id);
        }
    }
}
