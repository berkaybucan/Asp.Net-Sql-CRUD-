using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SirketProje.Models;

namespace SirketProje.Controllers
{
    public class DepartmanController : Controller
    {
        private readonly ILogger<DepartmanController> _logger;
        private readonly SirketDbContext _context;

        public DepartmanController(ILogger<DepartmanController> logger, SirketDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Departmanlar = _context.Departmen.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Departman dprtmn)
        {
            _context.Add(dprtmn);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Guncelle(int Id)
        {
            var GuncellenecekDepartman = _context.Departmen.FirstOrDefault(a =>a.DepartmanNo == Id);
            return View(GuncellenecekDepartman);
        }
        [HttpPost]
        public IActionResult Guncelle(Departman dprtmn)
        {
            _context.Update(dprtmn);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Sil(int Id)
        {
            var SilinecekDepartman = await _context.Departmen.FirstOrDefaultAsync(a => a.DepartmanNo == Id);
            _context.Remove(SilinecekDepartman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

