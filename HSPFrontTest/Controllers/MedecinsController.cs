using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ServiceMedecin.Controllers;


namespace ServiceMedecin.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class MedecinsController : Controller
    {
        private readonly HttpClient _httpClient;

        public MedecinsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            // Remplacez "http://api-gateway-url" par l'URL de votre API Gateway
            string apiGatewayUrl = "http://localhost:7111";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{apiGatewayUrl}/api/medecin");

                if (response.IsSuccessStatusCode)
                {
                    // Traitement des données reçues
                    var data = await response.Content.ReadAsStringAsync();
                    // ... Votre logique de traitement
                }
                else
                {
                    // Gérez les erreurs si la requête n'est pas réussie
                    // response.StatusCode, response.ReasonPhrase, etc.
                }
            }
            catch (HttpRequestException ex)
            {
                // Gérez les erreurs liées à la requête HTTP
                // ex.Message, etc.
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}





//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using HSPFrontTest.Data;
//using HSPFrontTest.Models;

//namespace HSPFrontTest.Controllers
//{
//    public class MedecinsController : Controller
//    {
//        private readonly AppDbContext _context;

//        public MedecinsController(AppDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Medecins
//        public async Task<IActionResult> Index()
//        {
//            return _context.Medecins != null ?
//                        View(await _context.Medecins.ToListAsync()) :
//                        Problem("Entity set 'AppDbContext.Medecins'  is null.");
//        }

//        // GET: Medecins/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Medecins == null)
//            {
//                return NotFound();
//            }

//            var medecin = await _context.Medecins
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (medecin == null)
//            {
//                return NotFound();
//            }

//            return View(medecin);
//        }

//        // GET: Medecins/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Medecins/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Nom,Specialite")] Medecin medecin)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(medecin);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(medecin);
//        }

//        // GET: Medecins/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Medecins == null)
//            {
//                return NotFound();
//            }

//            var medecin = await _context.Medecins.FindAsync(id);
//            if (medecin == null)
//            {
//                return NotFound();
//            }
//            return View(medecin);
//        }

//        // POST: Medecins/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Specialite")] Medecin medecin)
//        {
//            if (id != medecin.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(medecin);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!MedecinExists(medecin.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(medecin);
//        }

//        // GET: Medecins/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Medecins == null)
//            {
//                return NotFound();
//            }

//            var medecin = await _context.Medecins
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (medecin == null)
//            {
//                return NotFound();
//            }

//            return View(medecin);
//        }

//        // POST: Medecins/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Medecins == null)
//            {
//                return Problem("Entity set 'AppDbContext.Medecins'  is null.");
//            }
//            var medecin = await _context.Medecins.FindAsync(id);
//            if (medecin != null)
//            {
//                _context.Medecins.Remove(medecin);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool MedecinExists(int id)
//        {
//            return (_context.Medecins?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}
