using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SirketProje.Models;

namespace SirketProje.Controllers
{
    public class ProjeController : Controller
    {
        private readonly ILogger<ProjeController> _logger;
        private readonly SirketDbContext _context;

        public ProjeController(ILogger<ProjeController> logger, SirketDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Projeler = _context.Projes.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Proje prj)
        {
            _context.Add(prj);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Guncelle(int Id)
        {
            var GuncellenecekProje = _context.Projes.FirstOrDefault(a => a.ProjeNo == Id);
            return View(GuncellenecekProje);
        }
        [HttpPost]
        public IActionResult Guncelle(Proje prj)
        {
            _context.Update(prj);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Sil(int Id)
        {
            var SilinecekProje = await _context.Projes.FirstOrDefaultAsync(a => a.ProjeNo == Id);
            _context.Remove(SilinecekProje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }

}
