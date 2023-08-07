using LearnEfCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnEfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            _appDbContext.Products.Add(product);
            var res = await _appDbContext.SaveChangesAsync();
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var list = await _appDbContext.Products.ToListAsync();
            return Ok(list);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product input)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(p=>p.Id == input.Id);
            if(product != null)
            {
                product.Price = input.Price;
                product.Name = input.Name;
                await _appDbContext.SaveChangesAsync();
            }
            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(p=>p.Id == id);
            if(product != null)
            {
                _appDbContext.Products.Remove(product);
                await _appDbContext.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
