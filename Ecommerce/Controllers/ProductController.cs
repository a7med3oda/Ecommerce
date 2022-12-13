using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly EcommerceDbContext _context;
        public ProductController(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _context.Products.ToListAsync();
            return View(response);
        }
    }
}
