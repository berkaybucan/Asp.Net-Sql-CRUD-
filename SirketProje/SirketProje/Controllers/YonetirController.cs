using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SirketProje.Models;

namespace SirketProje.Controllers
{
    public class YonetirController : Controller
    {
        private readonly ILogger<YonetirController> _logger;
        private readonly SirketDbContext _context;

        public YonetirController(ILogger<YonetirController> logger, SirketDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Yonetir = _context.Yonetirs.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Yonetir ynt)
        {
            _context.Add(ynt);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Guncelle(int Id)
        {
            var GuncellenecekYonetir = _context.Yonetirs.FirstOrDefault(a => a.PersonelYonetirId == Id);
            return View(GuncellenecekYonetir);
        }
        [HttpPost]
        public IActionResult Guncelle(Yonetir ynt)
        {
            _context.Update(ynt);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Sil(int Id)
        {
            var SilinecekYonetir = await _context.Yonetirs.FirstOrDefaultAsync(a => a.PersonelYonetirId == Id);
            _context.Remove(SilinecekYonetir);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
