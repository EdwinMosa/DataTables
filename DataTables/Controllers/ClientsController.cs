using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataTables.Models;

namespace DataTables.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ClientInformationContext _context;

        public ClientsController(ClientInformationContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblClients.ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClient = await _context.TblClients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblClient == null)
            {
                return NotFound();
            }

            return View(tblClient);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Idnumber,GenderId,DateOfBirth,CountryId")] TblClient tblClient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblClient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblClient);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClient = await _context.TblClients.FindAsync(id);
            if (tblClient == null)
            {
                return NotFound();
            }
            return View(tblClient);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Name,Idnumber,GenderId,DateOfBirth,CountryId")] TblClient tblClient)
        {
            if (id != tblClient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblClient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblClientExists(tblClient.Id))
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
            return View(tblClient);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClient = await _context.TblClients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblClient == null)
            {
                return NotFound();
            }

            return View(tblClient);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var tblClient = await _context.TblClients.FindAsync(id);
            _context.TblClients.Remove(tblClient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblClientExists(decimal id)
        {
            return _context.TblClients.Any(e => e.Id == id);
        }
    }
}
