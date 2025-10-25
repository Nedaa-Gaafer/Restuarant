using Mapster;
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
    public class CartIMenuitemRepository : ICartIMenuitemRepository
    {
        private readonly RestorantDbContext _context;
        public CartIMenuitemRepository(RestorantDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CartMenuItem order)
        {
           await _context.CartMenuItems.AddAsync(order);
        }

        public void Delet(CartMenuItem item)
        {
           _context.CartMenuItems.Remove(item);
        }

        public async Task<IEnumerable<CartMenuItem>> GetAllCartItem()
        {
           return _context.CartMenuItems.Include(m=> m.Cart);
        }

        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public async Task Update()
        {
          //  await _context.CartMenuItems.Update(rel);
        }
    }
}
