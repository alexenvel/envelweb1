using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using envelweb.Data;
using envelweb.Models;

namespace envelweb.Controllers
{
    public class dadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public dadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //TESTEfgdgfdghd

        // GET: dados
        public async Task<IActionResult> Index(string textoPesquisa)
        {
            var lancamentos = from l in _context.dados
                              select l;
            if(!String.IsNullOrEmpty(textoPesquisa))
            {
                lancamentos = lancamentos.Where(p => p.categoria.Contains(textoPesquisa));
            }
            return View(await lancamentos.ToListAsync());
        }

        // GET: dados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dados = await _context.dados
                .FirstOrDefaultAsync(m => m.id == id);
            if (dados == null)
            {
                return NotFound();
            }

            return View(dados);
        }

        // GET: dados/Create jjjjjjjjjjjjjjj
        public IActionResult Create()
        {
            return View();
        }

        // POST: dados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,categoria,data,pagrec,banco,valor,juros,desconto,nota")] dados dados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dados);
        }

        // GET: dados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dados = await _context.dados.FindAsync(id);
            if (dados == null)
            {
                return NotFound();
            }
            return View(dados);
        }

        // POST: dados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,categoria,data,pagrec,banco,valor,juros,desconto,nota")] dados dados)
        {
            if (id != dados.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dadosExists(dados.id))
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
            return View(dados);
        }

        // GET: dados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dados = await _context.dados
                .FirstOrDefaultAsync(m => m.id == id);
            if (dados == null)
            {
                return NotFound();
            }

            return View(dados);
        }

        // POST: dados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dados = await _context.dados.FindAsync(id);
            _context.dados.Remove(dados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool dadosExists(int id)
        {
            return _context.dados.Any(e => e.id == id);
        }
    }
}
