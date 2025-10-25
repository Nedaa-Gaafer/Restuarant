using Mapster;
using Microsoft.EntityFrameworkCore;
using Restorant.Application.Contracts;
using Restorant.Application.IServices;
using Restorant.DTOs.MenuItemDtos;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Application.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IGenericRepository<MenuItem> _menuItemRepository;

        public MenuItemService(IGenericRepository<MenuItem> menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<int> CreateAsync(CreateMenuItemDto menuItemy)
        {
           var newMenuItem = menuItemy.Adapt<MenuItem>();
            await _menuItemRepository.CreateAsync(newMenuItem);
            var count = await  _menuItemRepository.SaveChangesAsync();
            return count;
        }

        public async Task<int> DeleteAsync(int menuItemId)
        {
            var FoundItem = await _menuItemRepository.GetById(menuItemId);
            _menuItemRepository.DeleteAsync(FoundItem);
            var count = await _menuItemRepository.SaveChangesAsync();
            return count;

        }

        public async Task<IEnumerable<GetAllMenuItemDtos>> GetAllMenuItemsAsync()
        {
            var allMenuItems = (await _menuItemRepository.GetAllAsync());


            List<GetAllMenuItemDtos> res = allMenuItems.Adapt<List<GetAllMenuItemDtos>>();
           
            return res;

        }

        public async Task<UpdateMenuItemDto> GetByIdAsync(int menuItemId)
        {
            var FoundItem = await _menuItemRepository.GetById(menuItemId);

            return FoundItem.Adapt<UpdateMenuItemDto>();
        }

        public async Task<IEnumerable<MenuItemDto>> MenuItemsAsync()
        {
            var menu = await GetAllMenuItemsAsync();
            List<MenuItemDto> allmenuItem = menu.Adapt<List<MenuItemDto>>();
            return allmenuItem;
        }

        public async Task<int> UpdateAsync(UpdateMenuItemDto menuItem)
        {
            var updatedMenueItem = menuItem.Adapt<MenuItem>();
            _menuItemRepository.Update(updatedMenueItem);
            var count = await _menuItemRepository.SaveChangesAsync();
            return count;

        }

        
    }
}
