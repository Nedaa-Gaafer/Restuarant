using Microsoft.EntityFrameworkCore;
using Restorant.DTOs.CartDtos;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Application.Contracts
{
    public interface IMenuitemOrderRepository
    {
      
        public Task CreateAsync(MenuItemOrder order);
        public Task DeleteAsync(MenuItemOrder order);
        public Task<IEnumerable<MenuItemOrder>> GetAllOrderItems(int orderId);
        public Task<int> SaveChangesAsync();
    }


    public interface ICartIMenuitemRepository
    {

        public Task CreateAsync(CartMenuItem order);
        public Task<IEnumerable<CartMenuItem>> GetAllCartItem();
        public Task Update();
        public Task<IEnumerable<CartMenuItem>> GetById(int id);
        public Task Delet(CartMenuItem item);
        public Task<int> DeletCart(Cart cart);
        public Task<int> SaveChangesAsync();

    }
}
