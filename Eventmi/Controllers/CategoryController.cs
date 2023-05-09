using Eventmi.Core.Contracts;
using Eventmi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eventmi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        private readonly ILogger logger;

        public CategoryController(
            ICategoryService _categoryService,
            ILogger<CategoryController> _logger)
        {
            categoryService = _categoryService;
            logger = _logger;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new CategoryModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await categoryService.AddAsync(model);
            }
            catch (Exception ex)
            {
                logger.LogError("CategoryController/Add", ex);

                ViewBag.ErrorMessage = "Something went wrong!";
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
