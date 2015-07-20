using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Products.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    public class Products : Controller
    {

        private int itemcount = 25; 
        private readonly IProductsContexts _context;

        public Products(IProductsContexts context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.Products
                .Take(25).ToArrayAsync();
     
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _context.Products
                .Where(p => p.ProductId == id)
                .FirstOrDefaultAsync();

            if (result == null)
            {
                return HttpNotFound(); 
            }
            else
            {
                return new JsonResult(result); 
            }

        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories
                .Take(itemcount)
                .ToArrayAsync();
        }

        public async Task<IActionResult> GetProductsByCategory(int categoryID)
        {
            var result = await _context.Products
                .Take(itemcount)
                .Where(p => p.CategoryId == categoryID)
                .ToListAsync();

            if (result == null)
            {
                return HttpNotFound(); 
            }
            else
            {
                return new JsonResult(result); 
            }

        }

        public async Task<IActionResult> GetNewProducts(int count)
        {
            if (count < 0)
            {
                return HttpBadRequest(); 
            }
            else if (count > 50)
            {
                count = 50; 
            }

            var result = await _context.Products
                .OrderByDescending(a => a.Created)
                .Take(count)
                .ToArrayAsync();

            return new JsonResult(result); 
        }

        public async Task<IActionResult> Search(string query)
        {
            var lowercase_query = query.ToLower();

            var result = await _context.Products
                .Where(p => p.Title.ToLower().Contains(lowercase_query))
                .Take(itemcount)
                .ToArrayAsync();

            return new JsonResult(result); 
        }




    }

}
