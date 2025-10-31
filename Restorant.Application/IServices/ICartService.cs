using Microsoft.EntityFrameworkCore;
using Restorant.DTOs.CartDtos;
using Restorant.DTOs.MenuItemDtos;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Application.IServices
{
    public interface ICartService
    {
        public Task<IEnumerable<Cart>> GetAllMenuItemsAsync();
        //public Task<AddOrderItem> AddOrderItemAsync(AddOrderItem order);
        public Task<Cart?> GetCartByUserId(string userId);
        public Task CreateOrderAsync(AddOrderItem order);
        public Task<int> UpdateAsync(AllOrderDto order);
        public Task<int> DeleteAsync(Cart cart,Order order );
        public Task<Cart> GetByIdAsync(int Id);
        public Task<double> CalculatTotalPrice();
        public Task<double> TotalPrice();
        public Task<double> Discunt();
        public Task DecreasQantity(int id);
        public Task IncreasQantity(int id);

        public Task<IEnumerable<AddOrderItem>> GetAllCart();
        public Task<int> SaveChangesAsync();
    }
}
