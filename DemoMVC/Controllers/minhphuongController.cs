using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class minhphuongController : Controller
    {
        private readonly ApplicationDbContext _context;

        public minhphuongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: minhphuong
        public async Task<IActionResult> Index()
        {
            return View(await _context.minhphuong.ToListAsync());
        }

        // GET: minhphuong/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minhphuong = await _context.minhphuong
                .FirstOrDefaultAsync(m => m.ID == id);
            if (minhphuong == null)
            {
                return NotFound();
            }

            return View(minhphuong);
        }

        // GET: minhphuong/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: minhphuong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Hoten,MSV")] minhphuong minhphuong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(minhphuong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(minhphuong);
        }

        // GET: minhphuong/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minhphuong = await _context.minhphuong.FindAsync(id);
            if (minhphuong == null)
            {
                return NotFound();
            }
            return View(minhphuong);
        }

        // POST: minhphuong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Hoten,MSV")] minhphuong minhphuong)
        {
            if (id != minhphuong.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(minhphuong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!minhphuongExists(minhphuong.ID))
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
            return View(minhphuong);
        }

        // GET: minhphuong/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minhphuong = await _context.minhphuong
                .FirstOrDefaultAsync(m => m.ID == id);
            if (minhphuong == null)
            {
                return NotFound();
            }

            return View(minhphuong);
        }

        // POST: minhphuong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var minhphuong = await _context.minhphuong.FindAsync(id);
            if (minhphuong != null)
            {
                _context.minhphuong.Remove(minhphuong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool minhphuongExists(string id)
        {
            return _context.minhphuong.Any(e => e.ID == id);
        }
    }
}
