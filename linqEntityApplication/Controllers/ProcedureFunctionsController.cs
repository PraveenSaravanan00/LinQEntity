using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using linqEntityApplication.Models;

namespace linqEntityApplication.Controllers
{
    public class ProcedureFunctionsController : Controller
    {
        private readonly PraveenContext _context;

        public ProcedureFunctionsController(PraveenContext context)
        {
            _context = context;
        }

        // GET: ProcedureFunctions
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProcedureFunctions.ToListAsync());
        }

        // GET: ProcedureFunctions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedureFunction = await _context.ProcedureFunctions
                .FirstOrDefaultAsync(m => m.Userid == id);
            if (procedureFunction == null)
            {
                return NotFound();
            }

            return View(procedureFunction);
        }

        // GET: ProcedureFunctions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcedureFunctions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Userid,Username,FirstName,LastName,Gender,Password,Price,Status")] ProcedureFunction procedureFunction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procedureFunction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procedureFunction);
        }

        // GET: ProcedureFunctions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedureFunction = await _context.ProcedureFunctions.FindAsync(id);
            if (procedureFunction == null)
            {
                return NotFound();
            }
            return View(procedureFunction);
        }

        // POST: ProcedureFunctions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Userid,Username,FirstName,LastName,Gender,Password,Price,Status")] ProcedureFunction procedureFunction)
        {
            if (id != procedureFunction.Userid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedureFunction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedureFunctionExists(procedureFunction.Userid))
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
            return View(procedureFunction);
        }

        // GET: ProcedureFunctions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedureFunction = await _context.ProcedureFunctions
                .FirstOrDefaultAsync(m => m.Userid == id);
            if (procedureFunction == null)
            {
                return NotFound();
            }

            return View(procedureFunction);
        }

        // POST: ProcedureFunctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procedureFunction = await _context.ProcedureFunctions.FindAsync(id);
            if (procedureFunction != null)
            {
                _context.ProcedureFunctions.Remove(procedureFunction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedureFunctionExists(int id)
        {
            return _context.ProcedureFunctions.Any(e => e.Userid == id);
        }
    }
}
