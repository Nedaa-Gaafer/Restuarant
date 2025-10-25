using Microsoft.AspNetCore.Mvc;
using Restorant.Application.IServices;
using Restorant.Application.Services;
using Restorant.DTOs.CategoryDtos;
using Restorant.DTOs.MenuItemDtos;

namespace Restorant.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService _catService;

        public CategoryController(ICategoryService catService)
        {
            _catService = catService;
        }

        public async Task<IActionResult> GetAllCategories()
        {
            var cat = await _catService.GetAllCategoriesAsync();

            return View(cat);
        }

        public async Task<IActionResult> Create()
        {
            CreateCategoryDto Cat = new CreateCategoryDto();
            return View(Cat);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto cat)
        {
            if (ModelState.IsValid == true)
            {
                await _catService.CreateCategoriesAsync(cat);
                return RedirectToAction("GetAllCategories");

            }
            else
            {
                return View("Create", cat);
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            var editeingCat = await _catService.GetCategoryById(id);

            return View(editeingCat);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(GetAllCategoriesDto cat)
        {
            await _catService.UpdateCategoriesAsync(cat);
            return RedirectToAction("GetAllCategories");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _catService.DeleteCategoriesAsync(id);
            return  RedirectToAction("GetAllCategories");
        }

        

    }
}
