using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KodApp.Models;

namespace KodApp.Controllers
{
    public class KodController : Controller
    {
        private readonly KodContext _context;

        public KodController(KodContext context)
        {
            _context = context;
        }

        // GET: Kod
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Kods.ToListAsync());
        //}

        public async Task<IActionResult> Index(string searchBy, string search, int? page)
        {
            if (searchBy == "title")
            {
                return View(await _context.Kods.Where(x => x.title.StartsWith(search) || search == null).ToListAsync());
            }
            else
            {
                return View(await _context.Kods.Where(x => x.artist.StartsWith(search) || search == null).ToListAsync());
            }
        }

        // GET: Kod/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kod = await _context.Kods
                .FirstOrDefaultAsync(m => m.videokeId == id);
            if (kod == null)
            {
                return NotFound();
            }

            return View(kod);
        }

        // GET: Kod/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kod/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("videokeId,songNumber,title,artist,description")] Kod kod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kod);
        }

        // GET: Kod/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kod = await _context.Kods.FindAsync(id);
            if (kod == null)
            {
                return NotFound();
            }
            return View(kod);
        }

        // POST: Kod/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("videokeId,songNumber,title,artist,description")] Kod kod)
        {
            if (id != kod.videokeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KodExists(kod.videokeId))
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
            return View(kod);
        }

        // GET: Kod/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kod = await _context.Kods
                .FirstOrDefaultAsync(m => m.videokeId == id);
            if (kod == null)
            {
                return NotFound();
            }

            return View(kod);
        }

        // POST: Kod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kod = await _context.Kods.FindAsync(id);
            _context.Kods.Remove(kod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KodExists(int id)
        {
            return _context.Kods.Any(e => e.videokeId == id);
        }
    }
}
