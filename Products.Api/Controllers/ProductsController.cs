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

        private readonly IProductsContexts _context;

        public Products(IProductsContexts context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.Products.ToListAsync();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await _context.Products
                .Where(p => p.ProductId == id)
                .FirstOrDefaultAsync();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //TODO: Fix
        }

        public static IEnumerable<Category> GetCategories()
        {
            //TODO: Replace with 
            yield return new Category { Name = "Brakes", Description = "Brakes description", ImageUrl = "product_brakes_disc.jpg" };
            yield return new Category { Name = "Lighting", Description = "Lighting description", ImageUrl = "product_lighting_headlight.jpg" };
            yield return new Category { Name = "Wheels & Tires", Description = "Wheels & Tires description", ImageUrl = "product_wheel_rim.jpg" };
            yield return new Category { Name = "Batteries", Description = "Batteries description", ImageUrl = "product_batteries_basic-battery.jpg" };
            yield return new Category { Name = "Oil", Description = "Oil description", ImageUrl = "product_oil_premium-oil.jpg" };
        }

        public async Task<List<Product>> GetNewProducts(int count)
        {
            return await _context.Products
                .OrderByDescending(a => a.Created)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> Search(string query)
        {
            var lowercase_query = query.ToLower();

            var q = _context.Products
                .Where(p => p.Title.ToLower().Contains(lowercase_query));

            return await q.ToListAsync();
        }




    }

}
