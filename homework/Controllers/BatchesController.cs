using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssessmentUser.Context;

namespace homework.Controllers
{
    public class BatchesController : Controller
    {
        private readonly Userdbcontext _context;

        public BatchesController(Userdbcontext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            var userdbcontext = _context.Batch.Include(b => b.Course);
            return View(await userdbcontext.ToListAsync());
        }

     
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Batch == null)
            {
                return NotFound();
            }

            var batch = await _context.Batch
                .Include(b => b.Course)
                .FirstOrDefaultAsync(m => m.BatchId == id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseName");
            return View();
        }

     
        [HttpPost]
       
        public async Task<IActionResult> Create([Bind("BatchId,BatchName,Trainer,StartDate,CourseId")] Batch batch)
        {
           
                _context.Add(batch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", batch.CourseId);
            return View(batch);
        }

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Batch == null)
            {
                return NotFound();
            }

            var batch = await _context.Batch.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", batch.CourseId);
            return View(batch);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BatchId,BatchName,Trainer,StartDate,CourseId")] Batch batch)
        {
            if (id != batch.BatchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(batch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchExists(batch.BatchId))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", batch.CourseId);
            return View(batch);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Batch == null)
            {
                return NotFound();
            }

            var batch = await _context.Batch
                .Include(b => b.Course)
                .FirstOrDefaultAsync(m => m.BatchId == id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Batch == null)
            {
                return Problem("Entity set 'Userdbcontext.Batch'  is null.");
            }
            var batch = await _context.Batch.FindAsync(id);
            if (batch != null)
            {
                _context.Batch.Remove(batch);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatchExists(int id)
        {
          return (_context.Batch?.Any(e => e.BatchId == id)).GetValueOrDefault();
        }
    }
}
