using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Restorant.Application.IServices;
using Restorant.DTOs.CartDtos;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Restorant.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartSrvice;
        private readonly IMenuItemService _menuItemService;
        private readonly IOrderService _orderService;

        public CartController(ICartService cartSrvice, IMenuItemService menuItemService, IOrderService orderService)
        {
            _cartSrvice = cartSrvice;
            _menuItemService = menuItemService;
            _orderService = orderService;
        }
        [Authorize]
        public async Task<IActionResult> Cart(int id)
        {
            var meal = await _menuItemService.GetByIdAsync(id);
            var addedMeal = meal.Adapt<AddOrderItem>();
            addedMeal.MenuItemId= id;
            addedMeal.UserId =  User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _cartSrvice.CreateOrderAsync(addedMeal);
           // var orders = await _cartSrvice.GetAllMenuItemsAsync();
            return RedirectToAction("MenuItems", "Meal");
        }

        public async Task<IActionResult> CartItems()
        {

             var orders = await _cartSrvice.GetAllCart();
            ViewBag.totalPrice = await _cartSrvice.TotalPrice();
            ViewBag.dicount = await _cartSrvice.Discunt();
            return View(orders);
        }

        public async Task<IActionResult> DecreaseQantity(int id)
        {
            await _cartSrvice.DecreasQantity(id);

            return RedirectToAction("CartItems"); 
        }
        public async Task<IActionResult> IcreaseQantity(int id)
        {
            await _cartSrvice.IncreasQantity(id);

            return RedirectToAction("CartItems");
        }

        [Authorize]
        public async Task<IActionResult>CreateOrder()
        {
           var userId =  User.FindFirstValue(ClaimTypes.NameIdentifier);
           var cart =  await _orderService.CreateAsync(userId);
            var order = await _orderService.GetOrderByUserId(userId);
            await  _cartSrvice.DeleteAsync(cart, order);
            return RedirectToAction("CartItems");
        }


    }
}
