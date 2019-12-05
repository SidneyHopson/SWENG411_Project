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
    public class ShotRecordsController : Controller
    {
        private readonly VARPRContext _context;

        public ShotRecordsController(VARPRContext context)
        {
            _context = context;
        }

        // GET: ShotRecords
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShotRecord.ToListAsync());
        }

        // GET: ShotRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shotRecord = await _context.ShotRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shotRecord == null)
            {
                return NotFound();
            }

            return View(shotRecord);
        }

        // GET: ShotRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShotRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Drug,DateOfShot,Notes")] ShotRecord shotRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shotRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shotRecord);
        }

        // GET: ShotRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shotRecord = await _context.ShotRecord.FindAsync(id);
            if (shotRecord == null)
            {
                return NotFound();
            }
            return View(shotRecord);
        }

        // POST: ShotRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Drug,DateOfShot,Notes")] ShotRecord shotRecord)
        {
            if (id != shotRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shotRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShotRecordExists(shotRecord.Id))
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
            return View(shotRecord);
        }

        // GET: ShotRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shotRecord = await _context.ShotRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shotRecord == null)
            {
                return NotFound();
            }

            return View(shotRecord);
        }

        // POST: ShotRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shotRecord = await _context.ShotRecord.FindAsync(id);
            _context.ShotRecord.Remove(shotRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShotRecordExists(int id)
        {
            return _context.ShotRecord.Any(e => e.Id == id);
        }
    }
}
