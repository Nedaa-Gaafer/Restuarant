using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Application.Contracts
{
    public interface IUserCartRepository
    {
        public Task<Cart> GetCartByUserId(string userId);
        public Task<int> SaveChangesAsync();
    }
}
