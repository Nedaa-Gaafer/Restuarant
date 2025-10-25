using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Restorant.Application.IServices;
using Restorant.Data;
using Restorant.DTOs.MenuItemDtos;
using Restorant.Models;
using Restorant.ViewModels;
using System.Text;

namespace Restorant.Controllers
{
    public class MealController : Controller
    {
        private readonly IMenuItemService _menuItemService;
        private readonly ICategoryService _catService;

        public MealController(IMenuItemService menuItemService, ICategoryService catService)
        {
            _menuItemService = menuItemService;
            _catService = catService;
        }


        //[Authorize]
        public async Task<IActionResult> GetAllMeals()
        {
            var meals = await _menuItemService.GetAllMenuItemsAsync();


            return View(meals);
        }

        
        public async Task<IActionResult> Create()
        {

            CreateMenuItemDto mealCat = new CreateMenuItemDto();
            var Categories = await _catService.GetAllCategoriesAsync() ;
            mealCat.Categories = Categories.ToList();
            return View(mealCat);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuItemDto menuItem)
        {
            if (ModelState.IsValid == true)
            {
                if (menuItem.CategoryId != 0)
                {
                    await _menuItemService.CreateAsync(menuItem);
                    return RedirectToAction("GetAllMeals");
                }
                else
                {
                    ModelState.AddModelError("CategoryId", "Select Category");
                    var Categories = await _catService.GetAllCategoriesAsync();
                    menuItem.Categories = Categories.ToList();
                    return View("Create", menuItem);
                }
                
            }
            else
            {

                var Categories = await _catService.GetAllCategoriesAsync();
                //menuItem.Categories = Categories.ToList();
                return View("Create", menuItem);
            }
            
        }

        public async Task<IActionResult> MenuItems()
        {
            var meals = await _menuItemService.MenuItemsAsync();

            return View(meals);
        }



        //public IActionResult Details(int id)
        //{
        //    var menuItem = _context.MenuItems.FirstOrDefault(m => m.Id == id);
        //    DetailsMenuItemWithSameItem bmt = new();
        //    bmt.MenuItem.Categories = _context.Categories.ToList();
        //    var category = _context.Categories.FirstOrDefault(c => c.Id == menuItem.CategoryId);
        //    //if(category.Name == "Chicken Burgers" || category.Name == "Beef Burgers")
        //    //{
        //    //    mealCat.Size = menuItem.Size;
        //    //}
        //    bmt.MenuItem.Name = menuItem.Name;
        //    bmt.MenuItem.Price = menuItem.Price;
        //    bmt.MenuItem.Size = menuItem.Size;
        //    bmt.MenuItem.ImageUrl = menuItem.ImageUrl;
        //    bmt.MenuItem.Description = menuItem.Description;
        //    bmt.MenuItem.CategoryId = menuItem.CategoryId;
        //    bmt.SameItems = _context.MenuItems.Where(c => c.Category.Name == category.Name).ToList();
        //    StringBuilder rename = new StringBuilder();
        //    ViewBag.cateName = category.Name;
        //    ViewBag.rename = rename;
        //    return View(bmt);
        //}

        public async Task <IActionResult> Edit(int id)
        {
            var editeingItem = await _menuItemService.GetByIdAsync(id);
            editeingItem.Categories = await _catService.GetAllCategoriesAsync();

            return View(editeingItem);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateMenuItemDto menuItem)
        {
            await _menuItemService.UpdateAsync(menuItem);
            return RedirectToAction("GetAllMeals");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _menuItemService.DeleteAsync(id);
            return RedirectToAction("GetAllMeals");
        }

        public async Task<IActionResult> CategoryItems(int id)
        {
            var items = (await _menuItemService.MenuItemsAsync()).ToList();
            
             var catItems = items.Where(items => items.CategoryId == id).ToList();
            return View("MenuItems", catItems);
        }
    }
}
