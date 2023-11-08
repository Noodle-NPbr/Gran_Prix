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
    public class EstoqueController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstoqueController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estoque
        public async Task<IActionResult> Index()
        {
              return _context.estoque != null ? 
                          View(await _context.estoque.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.estoque'  is null.");
        }

        // GET: Estoque/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.estoque == null)
            {
                return NotFound();
            }

            var estoqueModel = await _context.estoque
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estoqueModel == null)
            {
                return NotFound();
            }

            return View(estoqueModel);
        }

        // GET: Estoque/Create
        public IActionResult Create()
        {
            var fornecedor = _context.fornecedor.ToList();
            ViewBag.Fornecedor = fornecedor;

            return View();
        }

        // POST: Estoque/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Preco,Quantidade,Codigo,Fornecedor_Id")] EstoqueModel estoqueModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estoqueModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estoqueModel);
        }

        // GET: Estoque/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var fornecedor = _context.fornecedor.ToList();
            ViewBag.Fornecedor = fornecedor;

            if (id == null || _context.estoque == null)
            {
                return NotFound();
            }

            var estoqueModel = await _context.estoque.FindAsync(id);
            if (estoqueModel == null)
            {
                return NotFound();
            }
            return View(estoqueModel);
        }

        // POST: Estoque/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Preco,Quantidade,Codigo,Fornecedor_Id")] EstoqueModel estoqueModel)
        {
            if (id != estoqueModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estoqueModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstoqueModelExists(estoqueModel.Id))
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
            return View(estoqueModel);
        }

        // GET: Estoque/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.estoque == null)
            {
                return NotFound();
            }

            var estoqueModel = await _context.estoque
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estoqueModel == null)
            {
                return NotFound();
            }

            return View(estoqueModel);
        }

        // POST: Estoque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.estoque == null)
            {
                return Problem("Entity set 'ApplicationDbContext.estoque'  is null.");
            }
            var estoqueModel = await _context.estoque.FindAsync(id);
            if (estoqueModel != null)
            {
                _context.estoque.Remove(estoqueModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstoqueModelExists(int id)
        {
          return (_context.estoque?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
