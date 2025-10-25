using Microsoft.EntityFrameworkCore;
using Restorant.Application.Contracts;
using Restorant.Data;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Infrastructure
{
    public class UserCartRepository : IUserCartRepository
    {
        private readonly RestorantDbContext _context;

        public UserCartRepository(RestorantDbContext context)
        {
            _context = context;
        }

        public async Task<Cart?> GetCartByUserId(string userId)
        {
            return await (_context.Carts.Include(c => c.CartMenuItems).FirstOrDefaultAsync(c => c.UserId == userId));
            
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
