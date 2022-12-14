using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly EcommerceDbContext _context;                
        public CategoryController(EcommerceDbContext context)       // CTOR Dependency injection
        {
            _context = context;
        }

		public async Task<IActionResult> Index()
		{
			var response = await _context.Categories.ToListAsync();
            return View(response);
        }
    }
}
