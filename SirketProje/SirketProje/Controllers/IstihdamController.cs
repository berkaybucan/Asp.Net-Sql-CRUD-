using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SirketProje.Models;

namespace SirketProje.Controllers
{
    public class IstihdamController : Controller
    {
        private readonly ILogger<IstihdamController> _logger;
        private readonly SirketDbContext _context;

        public IstihdamController(ILogger<IstihdamController> logger, SirketDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Istihdamlar = _context.Istihdams.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Istihdam ist)
        {
            _context.Add(ist);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Guncelle(int Id)
        {
            var GuncellenecekIstihdam = _context.Istihdams.FirstOrDefault(a => a.IstihdamNo == Id);
            return View(GuncellenecekIstihdam);
        }
        [HttpPost]
        public IActionResult Guncelle(Istihdam ist)
        {
            _context.Update(ist);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Sil(int Id)
        {
            var SilinecekIstihdam = await _context.Istihdams.FirstOrDefaultAsync(a => a.IstihdamNo == Id);
            _context.Remove(SilinecekIstihdam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
