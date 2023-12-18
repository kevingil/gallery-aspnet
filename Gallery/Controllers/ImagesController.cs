using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gallery.Data;
using Gallery.Models;

namespace Gallery.Controllers
{
    public class ImagesController : Controller
    {
        private readonly GalleryContext _context;

        public ImagesController(GalleryContext context)
        {
            _context = context;
        }

        // GET: Imagess
        public async Task<IActionResult> Index()
        {
              return _context.Images != null ? 
                          View(await _context.Images.ToListAsync()) :
                          Problem("Entity set 'GalleryContext.Images'  is null.");
        }

        // GET: Imagess/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var Images = await _context.Images
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Images == null)
            {
                return NotFound();
            }

            return View(Images);
        }

        // GET: Imagess/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Imagess/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImagesUrl,Description,Timestamp,Rendertime,Blurhash64")] Images Images)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Images);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Images);
        }

        // GET: Imagess/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var Images = await _context.Images.FindAsync(id);
            if (Images == null)
            {
                return NotFound();
            }
            return View(Images);
        }

        // POST: Imagess/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImagesUrl,Description,Timestamp,Rendertime,Blurhash64")] Images Images)
        {
            if (id != Images.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Images);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagesExists(Images.Id))
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
            return View(Images);
        }

        // GET: Imagess/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var Images = await _context.Images
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Images == null)
            {
                return NotFound();
            }

            return View(Images);
        }

        // POST: Imagess/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Images == null)
            {
                return Problem("Entity set 'GalleryContext.Images'  is null.");
            }
            var Images = await _context.Images.FindAsync(id);
            if (Images != null)
            {
                _context.Images.Remove(Images);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImagesExists(int id)
        {
          return (_context.Images?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
