using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio2.Controllers
{
    public class PortfolioItemsController : Controller
    {
        private readonly myContext _context;

        public PortfolioItemsController(myContext context)
        {
            _context = context;
        }

        // GET: PortfolioItems
        public async Task<IActionResult> Index()
        {
            var myContext = _context.PortfolioItems.Include(p => p.Owner);
            return View(await myContext.ToListAsync());
        }

        // GET: PortfolioItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioItem = await _context.PortfolioItems
                .Include(p => p.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            return View(portfolioItem);
        }

        // GET: PortfolioItems/Create
        public IActionResult Create()
        {
            ViewData["OwnerName"] = new SelectList(_context.Owners, "Id", "full_name");
            return View();
        }

        // POST: PortfolioItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,project_name,description,image,OwnerId")] PortfolioItem portfolioItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(portfolioItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Id", portfolioItem.OwnerId);
            return View(portfolioItem);
        }

        // GET: PortfolioItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //ViewData["status"] = status;
            if (id == null)
            {
                return NotFound();
            }

            var portfolioItem = await _context.PortfolioItems.FindAsync(id);
            if (portfolioItem == null)
            {
                return NotFound();
            }
            ViewData["OwnerName"] = new SelectList(_context.Owners, "Id", "full_name", portfolioItem.OwnerId);
            return View(portfolioItem);
        }

        // POST: PortfolioItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,project_name,description,image,OwnerId")] PortfolioItem portfolioItem)
        {
            if (id != portfolioItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portfolioItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioItemExists(portfolioItem.Id))
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
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Id", portfolioItem.OwnerId);
            return View(portfolioItem);
        }

        // GET: PortfolioItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioItem = await _context.PortfolioItems
                .Include(p => p.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            return View(portfolioItem);
        }

        // POST: PortfolioItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var portfolioItem = await _context.PortfolioItems.FindAsync(id);
            _context.PortfolioItems.Remove(portfolioItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfolioItemExists(int id)
        {
            return _context.PortfolioItems.Any(e => e.Id == id);
        }
    }
}
