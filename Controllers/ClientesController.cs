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
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return _context.clientes != null ? 
                          View(await _context.clientes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.clientes'  is null.");
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.clientes == null)
            {
                return NotFound();
            }

            var clientesModel = await _context.clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientesModel == null)
            {
                return NotFound();
            }

            return View(clientesModel);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Telefone,CPF,Email")] ClientesModel clientesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientesModel);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.clientes == null)
            {
                return NotFound();
            }

            var clientesModel = await _context.clientes.FindAsync(id);
            if (clientesModel == null)
            {
                return NotFound();
            }
            return View(clientesModel);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Telefone,CPF,Email")] ClientesModel clientesModel)
        {
            if (id != clientesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesModelExists(clientesModel.Id))
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
            return View(clientesModel);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.clientes == null)
            {
                return NotFound();
            }

            var clientesModel = await _context.clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientesModel == null)
            {
                return NotFound();
            }

            return View(clientesModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.clientes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.clientes'  is null.");
            }
            var clientesModel = await _context.clientes.FindAsync(id);
            if (clientesModel != null)
            {
                _context.clientes.Remove(clientesModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesModelExists(int id)
        {
          return (_context.clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
