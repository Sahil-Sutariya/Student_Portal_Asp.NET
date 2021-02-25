using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentPortalFinal.Data;
using StudentPortalFinal.Models;

namespace StudentPortalFinal.Controllers
{
    public class StudentInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentInfoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.studentinfo.Include(s => s.student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInfo = await _context.studentinfo
                .Include(s => s.student)
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (studentInfo == null)
            {
                return NotFound();
            }

            return View(studentInfo);
        }

        // GET: StudentInfoes/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.student, "StudentId", "StudentId");
            return View();
        }

        // POST: StudentInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminId,courseName,proffessorName")] StudentInfo studentInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.student, "StudentId", "StudentId", studentInfo.AdminId);
            return View(studentInfo);
        }

        // GET: StudentInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInfo = await _context.studentinfo.FindAsync(id);
            if (studentInfo == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.student, "StudentId", "StudentId", studentInfo.AdminId);
            return View(studentInfo);
        }

        // POST: StudentInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminId,courseName,proffessorName")] StudentInfo studentInfo)
        {
            if (id != studentInfo.AdminId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentInfoExists(studentInfo.AdminId))
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
            ViewData["AdminId"] = new SelectList(_context.student, "StudentId", "StudentId", studentInfo.AdminId);
            return View(studentInfo);
        }

        // GET: StudentInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInfo = await _context.studentinfo
                .Include(s => s.student)
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (studentInfo == null)
            {
                return NotFound();
            }

            return View(studentInfo);
        }

        // POST: StudentInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentInfo = await _context.studentinfo.FindAsync(id);
            _context.studentinfo.Remove(studentInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentInfoExists(int id)
        {
            return _context.studentinfo.Any(e => e.AdminId == id);
        }
    }
}
