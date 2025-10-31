using Microsoft.EntityFrameworkCore;
using Restorant.Application.Contracts;
using Restorant.Data;
using Restorant.DTOs.CartDtos;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Infrastructure
{
    public class MenuitemOrderRepository : IMenuitemOrderRepository
    {
        private readonly RestorantDbContext _context;

        public MenuitemOrderRepository(RestorantDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(MenuItemOrder order)
        {
            await _context.MenuItemOrders.AddAsync(order);
        }

        public Task DeleteAsync(MenuItemOrder order)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MenuItemOrder>> GetAllOrderItems(int orderId)
        {
            var items = _context.MenuItemOrders.Where(i => i.OrderId == orderId);
            return await items.ToListAsync();
        }
        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }


}
