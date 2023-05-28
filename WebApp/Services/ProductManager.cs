using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.Services
{
    public class ProductManager
    {

        private readonly DataContext _context;

        public ProductManager(DataContext context)
        {
            _context=context;
        }

        public async Task AddAsync(ProductAddFormModel form)

        {
            var productCategoryEntity = await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == form.Category.Value);
            if (productCategoryEntity == null)
            
            {
            productCategoryEntity = new ProductCategoryEntity
            {
            CategoryName = form.Category.Name
            };
                _context.ProductCategories.Add(productCategoryEntity);
                await _context.SaveChangesAsync();  
            }
            var productEntity = new ProductEntity
            {

                Name = form.Name,
                Description = form.Description,
                Price = form.Price, 
                CategoryId = productCategoryEntity.Id
            };

            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();  
        }

        public async Task<IEnumerable<>> GetAllAsync()
        {

        }
    }
}
