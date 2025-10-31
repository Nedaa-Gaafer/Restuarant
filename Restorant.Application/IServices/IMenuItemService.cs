using Restorant.DTOs.MenuItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Application.IServices
{
    public interface IMenuItemService
    {
        public Task<IEnumerable<GetAllOrdersDto>> GetAllMenuItemsAsync();

        public Task<IEnumerable<MenuItemDto>> MenuItemsAsync();
        public Task<int> CreateAsync(CreateMenuItemDto menuItemy);
        public Task<int> UpdateAsync(UpdateMenuItemDto menuItem);
        public Task<int> DeleteAsync(int menuItemId);
        public Task<UpdateMenuItemDto> GetByIdAsync(int menuItemId);
    }
}
