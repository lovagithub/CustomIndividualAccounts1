using WebApp.Models;
using WebApp.Models.Entities;
using WebApp.Repositories;
namespace WebApp.Services
{
    public class ProductCategoryManager
    {
        private readonly Repo<ProductCategoryEntity> _categoryRepo;

        public ProductCategoryManager(Repo<ProductCategoryEntity> categoryRepo)
        {
            _categoryRepo=categoryRepo;
        }
        public async Task<ProductCategoryEntity> GetOrCreateAsync(ProductCategoryModel model)
        {
            var categiryEntity = await _categoryRepo.GetAsync(x => x.Id == model.Value);
            if (categiryEntity == null)
                categiryEntity = await _categoryRepo.AddAsync(new ProductCategoryEntity { CategoryName = model.Name });
            return categiryEntity;

        }
    }
}
