using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models;
using WebApp.Models.Entities;
using WebApp.Repositories;

namespace WebApp.Services
{
    public class ProductManager
    {
        private readonly ProductCategoryManager _categoryManager;
        private readonly Repo<ProductEntity> _productManager;


        public ProductManager(ProductCategoryManager categoryManager, Repo<ProductEntity> productManagere = null, Repo<ProductEntity> productManager = null)
        {
            _categoryManager = categoryManager;         
            _productManager = productManager;
        }

        public async Task AddAsync(ProductAddFormModel form)

        {

            ProductEntity product = form;
            product.CategoryId = (await _categoryManager.GetOrCreateAsync(form.Category)).Id;

            await _productManager.AddAsync(product);
        } 

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()

        {
            return await _productManager.GetAllAsync();
        }
    }
}
