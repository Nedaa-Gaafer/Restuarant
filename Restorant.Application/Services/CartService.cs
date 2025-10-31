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
        private readonly IGenericRepository<Order> _ordrRepository;
        private readonly IMenuitemOrderRepository _ordweItemtRepository;

        public CartService(IGenericRepository<Cart> cartRepository, ICartIMenuitemRepository carItemtRepository, IUserCartRepository carUser, IGenericRepository<MenuItem> menuItemRepository, IGenericRepository<Order> ordrRepository, IMenuitemOrderRepository ordweItemtRepository)
        {
            _cartRepository = cartRepository;
            _carItemtRepository = carItemtRepository;
            _carUser = carUser;
            _menuItemRepository = menuItemRepository;
            _ordrRepository = ordrRepository;
            _ordweItemtRepository = ordweItemtRepository;
        }



        //++++++++++++++++++++++++
        //public async Task<AddOrderItem> AddOrderItemAsync(AddOrderItem order)
        //{
        //    return order  ;
        //}



        public async Task CreateOrderAsync(AddOrderItem order)
        {
            var cart = await _carUser.GetCartByUserId(order.UserId);
            if(cart == null)
            {
                var newOrder = new Cart();
                newOrder.Status = OrderStatus.Pending;
                await _cartRepository.CreateAsync(newOrder);
                await _cartRepository.SaveChangesAsync();
                var totalPrice = await TotalPrice();
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
                    cart.OrderTotalPrice = await TotalPrice();
                    await _cartRepository.Update(cart);

                }
                else 
                {
                    await _carItemtRepository.CreateAsync(new CartMenuItem()
                    {
                        CartId = cart.Id,
                        MenuItemId = order.Id,
                        Quantity = 1
                    });
                    cart.OrderTotalPrice = await TotalPrice();
                    await _cartRepository.Update(cart);

                }
                await _carItemtRepository.SaveChangesAsync();

                await _cartRepository.SaveChangesAsync();

               

                await _carItemtRepository.SaveChangesAsync();
              //  var totalPrice = await TotalPrice();

            }

            
        }
////===========================================================================
//        public Task<int> CreateOrderAsync()
//        {
//            throw new NotImplementedException();
//        }
//===========================================================================
        public async Task DecreasQantity(int id)
        {
            var rel = await _carItemtRepository.GetAllCartItem();
            var found = rel.FirstOrDefault(c => c.MenuItemId == id);
            if(found?.Quantity > 0)
            {
                found.Quantity -= 1;
                if (found?.Quantity == 0)
                {
                    await _carItemtRepository.Delet(found);
                }
            }
           
            await _carItemtRepository.SaveChangesAsync();
        }

        public async Task IncreasQantity(int id)
        {
            var rel = await _carItemtRepository.GetAllCartItem();
            var found = rel.FirstOrDefault(c => c.MenuItemId == id);
            
             found.Quantity += 1;

            await _carItemtRepository.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Cart cart, Order order)
        {
            var listItem = await _carItemtRepository.GetById(cart.Id);
            cart.OrderTotalPrice = await Discunt();
            order.OrderTotalPrice = await Discunt();
            await _cartRepository.Update(cart);
            await _ordrRepository.Update(order);
            await _ordrRepository.SaveChangesAsync();
            foreach (var item in listItem)
            {
                var menuItem = item.Adapt<MenuItemOrder>();
                menuItem.OrderId = order.Id;
                await _ordweItemtRepository.CreateAsync(menuItem);
                await _ordweItemtRepository.SaveChangesAsync();
                await _carItemtRepository.Delet(item);
            }
            // return await _cartRepository.SaveChangesAsync();
            //return await _carItemtRepository.DeletCart(order);
            return 1;
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

        public async Task<Cart> GetByIdAsync(int Id)
        {
            return await _cartRepository.GetById(Id);
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
                totalPrice += meal.Price;
            }

            return totalPrice;
        }

        public async Task<double> CalculatTotalPrice()
        {
            var OrderTotalPrice = 0.0;
            var all = await _carItemtRepository.GetAllCartItem();
            if (all != null)
            {
                foreach (var order in all)
                {
                    var item = await _menuItemRepository.GetById(order.MenuItemId);
                    OrderTotalPrice += item.Price * order.Quantity;
                }

            }
            return OrderTotalPrice;
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
