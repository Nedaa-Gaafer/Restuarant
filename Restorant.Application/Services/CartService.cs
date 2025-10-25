using Mapster;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Restorant.Application.Contracts;
using Restorant.Application.IServices;
using Restorant.DTOs.CartDtos;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IGenericRepository<Cart> _cartRepository;
        private readonly ICartIMenuitemRepository _carItemtRepository;
        private readonly IUserCartRepository _carUser;
        private readonly IGenericRepository<MenuItem> _menuItemRepository;

        public CartService(IGenericRepository<Cart> cartRepository, ICartIMenuitemRepository carItemtRepository, IUserCartRepository carUser, IGenericRepository<MenuItem> menuItemRepository)
        {
            _cartRepository = cartRepository;
            _carItemtRepository = carItemtRepository;
            _carUser = carUser;
            _menuItemRepository = menuItemRepository;
        }

        public async Task<AddOrderItem> AddOrderItemAsync(AddOrderItem order)
        {
            return order  ;
        }

        public double CalculatTotalPrice(Cart carts)
        {
            if (carts.CartMenuItems == null || carts.CartMenuItems.Any())
                return 0;
            foreach (var order in carts.CartMenuItems)
            {
                carts.OrderTotalPrice = order.MenuItem.Price * order.Quantity;
            }

            return carts.OrderTotalPrice;
        }

        public async Task CreateOrderAsync(AddOrderItem order)
        {
            var cart = await _carUser.GetCartByUserId(order.UserId);
            if(cart == null)
            {
                var newOrder = new Cart();
                newOrder.Status = OrderStatus.Pending;
                await _cartRepository.CreateAsync(newOrder);
                await _cartRepository.SaveChangesAsync();
                var totalPrice = CalculatTotalPrice(newOrder);
                newOrder.OrderTotalPrice = totalPrice;
                var carmui = new CartMenuItem();
                carmui.CartId = newOrder.Id;
                carmui.MenuItemId = order.MenuItemId;
                newOrder.UserId = order.UserId;
                await _carItemtRepository.CreateAsync(carmui);
                await _carItemtRepository.SaveChangesAsync();
                await _cartRepository.SaveChangesAsync();

            }
            else
            {
                var all = await _carItemtRepository.GetAllCartItem();
                var found = all.FirstOrDefault(a=> a.MenuItemId == order.MenuItemId);
               
                if (found != null)
                {
                    found.Quantity += 1;
                }
                else 
                {
                    await _carItemtRepository.CreateAsync(new CartMenuItem()
                    {
                        CartId = cart.Id,
                        MenuItemId = order.Id,
                        Quantity = 1
                    });
                    await _carItemtRepository.SaveChangesAsync();
                }
                    
                await _carItemtRepository.SaveChangesAsync();
                var totalPrice = CalculatTotalPrice(cart);
                cart.OrderTotalPrice = await TotalPrice(); 
               await _cartRepository.SaveChangesAsync();

            }

            
        }

       

        public Task<int> CreateOrderAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DecreasQantity(int id)
        {
            var rel = await _carItemtRepository.GetAllCartItem();
            var found =  rel.FirstOrDefault(c => c.MenuItemId == id);
            if(found.Quantity > 0)
            {
                found.Quantity -= 1;
            }
            else if (found.Quantity == 0)
            {
                _carItemtRepository.Delet(found);
            }
            await _carItemtRepository.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<double> Discunt()
        {
            var price = await TotalPrice();
            if(price >500)
            {
                return price - (price * .2);
            }
            else
            {
                return price;
            }
        }

        public async Task<IEnumerable<AddOrderItem>> GetAllCart()
        {
            List<AddOrderItem> items = new();
            var rel = await _carItemtRepository.GetAllCartItem();
             foreach(var item in rel)
            {
              var x = await _menuItemRepository.GetById(item.MenuItemId);
              var y = item.Adapt<AddOrderItem>();
                y.Quantity = item.Quantity;
                y.Name = x.Name;
                y.ImageUrl = x.ImageUrl;
                y.Price = item.Quantity * x.Price;
                y.MenuItemId = item.MenuItemId;
                items.Add(y);
            }

            return items;
        }

        public async Task<IEnumerable<Cart>> GetAllMenuItemsAsync()
        {
          return await _cartRepository.GetAllAsync();
        
        }

        public Task<AllOrderDto> GetByIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<Cart?> GetCartByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _carItemtRepository.SaveChangesAsync();
        }

        public async Task<double> TotalPrice()
        {
            var item = await GetAllCart();
            var totalPrice = 0.0;
            foreach(var meal in item)
            {
                totalPrice += meal.Price * meal.Quantity;
            }

            return totalPrice;
        }

        public Task<int> UpdateAsync(AllOrderDto order)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<AddOrderItem>> CreateAsync(AddOrderItem order)
        //{
        //    var CartOrder = new AllOrderDto();
        //    CartOrder.AddOrderItemrs.Add(order);
        //    List<AddOrderItem> cart = new();

        //    var addedOrder = CartOrder.Adapt<Cart>();
        //    addedOrder.OrderTotalPrice = 68.6;
        //    await _cartRepository.CreateAsync(addedOrder);

        //    foreach (var item in CartOrder.AddOrderItemrs)
        //        {
        //            var ItemCart = new OrderCartDtoRel();

        //            ItemCart.MenuItemId = item.MenuItem.Id;
        //            ItemCart.CartId = addedOrder.Id;
        //            ItemCart.Quantity = item.Quantity;
        //          var x=  await CreateOrderAsyncItem(ItemCart);
        //        var re = await _cartRepository.SaveChangesAsync();

        //    }




        //    return  cart;

        //}

        //public async Task<int> CreateOrderAsyncItem(OrderCartDtoRel orderItem)
        //{
        //    var menuItem = orderItem.Adapt<CartMenuItem>();
        //    await _carItemtRepository.CreateAsync(menuItem);
        //   var re = await _cartRepository.SaveChangesAsync();
        //    return re;

        //}

        //public Task<int> DeleteAsync(int orderId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<AllOrderDto>> GetAllMenuItemsAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<AddOrderItem>> GetCart()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> UpdateAsync(AllOrderDto order)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<AllOrderDto> ICartService.GetByIdAsync(int orderId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
