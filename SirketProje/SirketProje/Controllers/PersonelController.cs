using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SirketProje.Models;
using System.Diagnostics;

namespace SirketProje.Controllers
{
    public class PersonelController : Controller
    {
        private readonly ILogger<PersonelController> _logger;
        private readonly SirketDbContext _context;

        public PersonelController(ILogger<PersonelController> logger, SirketDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Personeller = _context.Personels.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Personel prsnl)
        {
            _context.Add(prsnl);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Guncelle(string Id)
        {
            var GuncellenecekPersonel= _context.Personels.FirstOrDefault(a => a.Tcno == Id);
            return View(GuncellenecekPersonel);
        }
        [HttpPost]
        public IActionResult Guncelle(Personel prsnl)
        {
            _context.Update(prsnl);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Sil(string Id)
        {
            var SilinecekKisi= await _context.Personels.FirstOrDefaultAsync(a => a.Tcno==Id);
            _context.Remove(SilinecekKisi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
