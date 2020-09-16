using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoatRental.Models;

namespace BoatRental.Controllers
{
    public class RegistersController : Controller
    {
        private readonly BoatRentalContext _context;

        public RegistersController(BoatRentalContext context)
        {
            _context = context;
        }

        // GET: Registers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblRegister.ToListAsync());
        }

        // GET: Registers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRegister = await _context.TblRegister
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblRegister == null)
            {
                return NotFound();
            }

            return View(tblRegister);
        }

        // GET: Registers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BoatName,HourlyRate")] TblRegister tblRegister)
        {
            if (ModelState.IsValid)
            {
                var isExist = _context.TblRegister.ToList().Exists(x => x.BoatName.ToLower() == tblRegister.BoatName.ToLower() && x.HourlyRate == tblRegister.HourlyRate);
                if (isExist)
                {
                    return RedirectToAction(nameof(Error));
                }

                _context.Add(tblRegister);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblRegister);
        }
        public ActionResult Error()
        {
            return View();
        }

        // GET: Registers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRegister = await _context.TblRegister.FindAsync(id);
            if (tblRegister == null)
            {
                return NotFound();
            }
            return View(tblRegister);
        }

        // POST: Registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BoatName,HourlyRate")] TblRegister tblRegister)
        {
            if (id != tblRegister.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblRegister);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblRegisterExists(tblRegister.Id))
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
            return View(tblRegister);
        }

        // GET: Registers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRegister = await _context.TblRegister
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblRegister == null)
            {
                return NotFound();
            }

            return View(tblRegister);
        }

        // POST: Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblRegister = await _context.TblRegister.FindAsync(id);
            _context.TblRegister.Remove(tblRegister);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblRegisterExists(int id)
        {
            return _context.TblRegister.Any(e => e.Id == id);
        }
    }
}
