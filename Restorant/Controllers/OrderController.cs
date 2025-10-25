//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Restorant.Data;
//using Restorant.Models;
//using Restorant.ViewModels;
//using System.Threading.Tasks;

//namespace Restorant.Controllers
//{
//    public class OrderController : Controller 
//    {
//        private readonly RestorantDbContext _context;
//        public OrderController()
//        {
//            _context = new();
//        }
//        public IActionResult CartOrder(int id)
//        {
//            var meal = _context.MenuItems.FirstOrDefault(m => m.Id == id);
//            var order = new Cart();
//            var findItem = Cart.AllOrderItem.FirstOrDefault(m => m.MenuItem.Id == id);
           
//                if (findItem != null && findItem.Quantity >=0)
//                {
//                    findItem.Quantity = findItem.Quantity + 1;
//                    findItem.Price = findItem.Quantity * findItem.MenuItem.Price;
//                }
//                else if(findItem == null)
//                {
//                    order.MenuItem.Id = meal.Id;
//                    order.MenuItem.Name = meal.Name;
//                    order.MenuItem.Price = meal.Price;
//                    order.MenuItem.Size = meal.Size;
//                    order.MenuItem.ImageUrl = meal.ImageUrl;
//                    order.MenuItem.Description = meal.Description;
//                    order.MenuItem.CategoryId = meal.CategoryId;

//                    order.Price = order.Quantity * order.MenuItem.Price;
//                    Cart.AllOrderItem.Add(order);
//                }
//                else
//                {
//                    Cart.AllOrderItem.Remove(findItem);
//                }


//                //if (findItem != null)
//                //{
//                //    findItem.Quantity = findItem.Quantity + 1;
//                //    findItem.Price = findItem.Quantity * findItem.MenuItem.Price;
//                //}
//                //else
//                //{
//                //    order.MenuItem.Id = meal.Id;
//                //    order.MenuItem.Name = meal.Name;
//                //    order.MenuItem.Price = meal.Price;
//                //    order.MenuItem.Size = meal.Size;
//                //    order.MenuItem.ImageUrl = meal.ImageUrl;
//                //    order.MenuItem.Description = meal.Description;
//                //    order.MenuItem.CategoryId = meal.CategoryId;

//                //    order.Price = order.Quantity * order.MenuItem.Price;
//                //    Cart.AllOrderItem.Add(order);
//                //}

//                return View(Cart.AllOrderItem);
//        }

//        public IActionResult DecreaseQuantity(int id)
//        {
//            var findItem = Cart.AllOrderItem.FirstOrDefault(m => m.MenuItem.Id == id);
//            if (findItem.Quantity >= 1)
//            {
                
//                    findItem.Quantity -= 2;
                
//            }
//            return RedirectToAction("CartOrder", new { id = findItem.MenuItem.Id });
//        }



//        public async Task<IActionResult> ConfirmOrder()
//        {
//            var order = new Order();
//            var totalPrice = 0.0;
//            foreach(var item in Cart.AllOrderItem)
//            {

//                totalPrice += item.Quantity * item.MenuItem.Price;
                              
//            }
//            order.OrderTotalPrice = (decimal)totalPrice;
//            order.Status = OrderStatus.Confirmed;
//            order.OrderDate = DateTime.Now;
//           // order.UserId = "1";
//            await _context.Orders.AddAsync(order);
//            await _context.SaveChangesAsync();

//            foreach (var item in Cart.AllOrderItem)
//            {

//                var itemOrder = new MenuItemOrder();

//                itemOrder.Quantity = item.Quantity;
//                itemOrder.MenuItemId = item.MenuItem.Id;
//                itemOrder.OrderId = order.Id;
//                await _context.MenuItemOrders.AddAsync(itemOrder);
//                await _context.SaveChangesAsync();
                

//            }

//            Cart.AllOrderItem.Clear();
//            return View();
//        }

//    }
//}
