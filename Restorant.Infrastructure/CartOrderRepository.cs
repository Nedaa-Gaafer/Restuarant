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

        public async Task Delet(CartMenuItem item)
        {
           _context.CartMenuItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<int> DeletCart(Cart cart)
        {
             _context.Carts.Remove(cart);
           return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CartMenuItem>> GetAllCartItem()
        {
            return await _context.CartMenuItems.ToListAsync();
        }

        public async Task<IEnumerable<CartMenuItem>> GetById(int id)
        {
            return await (_context.CartMenuItems.Where(C => C.CartId == id)).ToListAsync();
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
