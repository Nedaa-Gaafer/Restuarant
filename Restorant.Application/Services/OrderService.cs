using Mapster;
using Microsoft.EntityFrameworkCore;
using Restorant.Application.Contracts;
using Restorant.Application.IServices;
using Restorant.DTOs.CartDtos;
using Restorant.DTOs.MenuItemDtos;
using Restorant.DTOs.OrderDtos;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<Cart> _cartRepository;

        private readonly IMenuitemOrderRepository _ordweItemtRepository;
        private readonly IUserCartRepository _carUser;

        private readonly IGenericRepository<MenuItem> _menuItemRepository;

        public OrderService(IGenericRepository<Order> orderRepository, IGenericRepository<Cart> cartRepository, IMenuitemOrderRepository ordweItemtRepository, IUserCartRepository carUser, IGenericRepository<MenuItem> menuItemRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _ordweItemtRepository = ordweItemtRepository;
            _carUser = carUser;
            _menuItemRepository = menuItemRepository;
        }

        public async Task<Cart> CreateAsync(string userId)
        {
            var cart = await _carUser.GetCartByUserId(userId);
            var cartMap = cart.Adapt<CartDto>();
            var order = cartMap.Adapt<Order>();
            order.OrderDate = DateTime.Now;
            var x = await _orderRepository.CreateAsync(order);
            await _orderRepository.SaveChangesAsync();
            return cart;

        }

        public async Task<int> CreateOrderMenuItems(CartMenuItem rel)
        {
            var orderItem = rel.Adapt<MenuItemOrder>();
            await _ordweItemtRepository.CreateAsync(orderItem);
            return await _ordweItemtRepository.SaveChangesAsync();



        }

        public async Task<IEnumerable<GetAllOrdersDto>> GetAllorder()
        {
          var orders = await _orderRepository.GetAllAsync();
            return orders.Adapt<List<GetAllOrdersDto>>();
        }


        public async Task<Order> GetOrderByUserId(string id)
        {
           var orders = await _orderRepository.GetAllAsync();
            //orders.OrderBy(o => o.OrderDate);
            var foundOrder = (await orders.Where(o => o.UserId == id).ToListAsync()).MaxBy(o => o.Id);
            return foundOrder;

        }

        public async Task<IEnumerable<GetUserOrdersDto>> GetOrdersByUserId(string id)
        {
            var orders = await _orderRepository.GetAllAsync();
            var foundOrder = await (orders.Where(o => o.UserId == id)).ToListAsync();
             var ordesrDto = foundOrder.Adapt<List<GetUserOrdersDto>>();
            foreach(var item in ordesrDto)
            {
                var meals = await GetAllOrderItem(item.Id);
                item.OrderItems = meals;

            }


            return ordesrDto;

        }

        public async Task<IEnumerable<AddOrderItem>> GetAllOrderItem(int orderId)
        {
            var items = await _ordweItemtRepository.GetAllOrderItems(orderId);
            var listItems = new List<AddOrderItem>();
            foreach(var item in items)
            {
               var meal = await _menuItemRepository.GetById(item.MenuItemId);
                var mealDto = meal.Adapt<AddOrderItem>();
                mealDto.Quantity = item.Quantity;
                listItems.Add(mealDto);

            }

            return  listItems;
        }
    }
}
