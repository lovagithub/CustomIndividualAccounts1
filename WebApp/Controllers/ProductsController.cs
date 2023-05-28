using Microsoft.AspNetCore.Mvc;
using WebApp.Models.ViewModels;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductManager _productManager;

        public ProductsController(ProductManager productManager)
        {
            _productManager=productManager;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productManager.GetAllAsync();
            ViewData["Title"] = "Products";
            return View(products);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Add(ProductAddViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _productManager.AddAsync(viewModel.Form);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        public IActionResult Search()
        {
            ViewData["Title"] = "Search for products";
            return View();
        }
    }
}
