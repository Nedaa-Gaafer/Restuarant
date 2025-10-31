using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Restorant.DTOs.CartDtos;
using Restorant.DTOs.MenuItemDtos;
using Restorant.DTOs.OrderDtos;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Application.IServices
{
    public interface IOrderService
    {
       // public Task<IEnumerable<GetAllOrdersDto>> GetAllorder();
        public Task<Order> GetOrderByUserId(string id);

        //public Task<IEnumerable<MenuItemDto>> MenuItemsAsync();
        public Task<Cart> CreateAsync(string userId);
        public Task<int> CreateOrderMenuItems(CartMenuItem rel);
        public Task<IEnumerable<AddOrderItem>> GetAllOrderItem(int orderId);
        public Task<IEnumerable<GetUserOrdersDto>> GetOrdersByUserId(string id);
       // public Task<int> UpdateAsync(UpdateMenuItemDto menuItem);
       // public Task<int> DeleteAsync(int menuItemId);
       // public Task<UpdateMenuItemDto> GetByIdAsync(int menuItemId);
    }
}
