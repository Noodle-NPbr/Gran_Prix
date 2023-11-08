using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gran_Prix.Data;
using Gran_Prix.Models;

namespace Gran_Prix.Controllers
{
    public class CaixaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CaixaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Caixa
        public async Task<IActionResult> Index()
        {
              return _context.caixa != null ? 
                          View(await _context.caixa.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.caixa'  is null.");
        }

        // GET: Caixa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.caixa == null)
            {
                return NotFound();
            }

            var caixaModel = await _context.caixa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caixaModel == null)
            {
                return NotFound();
            }

            return View(caixaModel);
        }

        // GET: Caixa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Caixa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Entrada,Saida,Data,Pedido_Id")] CaixaModel caixaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caixaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caixaModel);
        }

        // GET: Caixa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.caixa == null)
            {
                return NotFound();
            }

            var caixaModel = await _context.caixa.FindAsync(id);
            if (caixaModel == null)
            {
                return NotFound();
            }
            return View(caixaModel);
        }

        // POST: Caixa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Entrada,Saida,Data,Pedido_Id")] CaixaModel caixaModel)
        {
            if (id != caixaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caixaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaixaModelExists(caixaModel.Id))
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
            return View(caixaModel);
        }

        // GET: Caixa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.caixa == null)
            {
                return NotFound();
            }

            var caixaModel = await _context.caixa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caixaModel == null)
            {
                return NotFound();
            }

            return View(caixaModel);
        }

        // POST: Caixa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.caixa == null)
            {
                return Problem("Entity set 'ApplicationDbContext.caixa'  is null.");
            }
            var caixaModel = await _context.caixa.FindAsync(id);
            if (caixaModel != null)
            {
                _context.caixa.Remove(caixaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaixaModelExists(int id)
        {
          return (_context.caixa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
