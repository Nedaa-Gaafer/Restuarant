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
      
        public Task<MenuItemOrder> CreateAsync(MenuItemOrder order);
        public Task<int> SaveChangesAsync();
    }


    public interface ICartIMenuitemRepository
    {

        public Task CreateAsync(CartMenuItem order);
        public Task<IEnumerable<CartMenuItem>> GetAllCartItem();
        public Task Update();
        public void Delet(CartMenuItem item);
        public Task<int> SaveChangesAsync();

    }
}
