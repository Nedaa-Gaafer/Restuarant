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

        public Task<MenuItemOrder> CreateAsync(MenuItemOrder order)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }


}
