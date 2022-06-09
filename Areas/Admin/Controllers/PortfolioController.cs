using BizLand.DAL;
using BizLand.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BizLand.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        private AppDbContext _db { get; set; }
        public PortfolioController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Items()
        {
            List<PortfolioItem> portfolio = await _db.Portfolios.Include(el=>el.Category).ToListAsync(); 
            return View(portfolio);
        }
    }
}
