﻿using WebApp.Models.Entities;

namespace WebApp.Models
{
    public class ProductAddFormModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public ProductCategoryModel Category { get; set; } = new ProductCategoryModel();

        public static implicit operator ProductEntity(ProductAddFormModel model)
        {
            return new ProductEntity
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };
        }
    }
}
