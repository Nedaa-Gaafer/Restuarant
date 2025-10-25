using Mapster;
using Restorant.DTOs.CartDtos;
using Restorant.DTOs.CategoryDtos;
using Restorant.DTOs.MenuItemDtos;
using Restorant.DTOs.UserDtos;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Application.Mappers
{
    public class MapsterConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<MenuItem, GetAllMenuItemDtos>.NewConfig().TwoWays();
            TypeAdapterConfig<MenuItem, GetAllMenuItemDtos>.NewConfig().TwoWays();
            TypeAdapterConfig<GetAllMenuItemDtos, MenuItemDto>.NewConfig().TwoWays();
            TypeAdapterConfig<MenuItem, UpdateMenuItemDto>.NewConfig().TwoWays();
            TypeAdapterConfig<AddOrderItem, UpdateMenuItemDto>.NewConfig().TwoWays();
            TypeAdapterConfig<MenuItem, AddOrderItem>.NewConfig().TwoWays();
            TypeAdapterConfig<Category, GetAllCategoriesDto>.NewConfig().TwoWays();
            TypeAdapterConfig<Category, CreateCategoryDto>.NewConfig().TwoWays();
            TypeAdapterConfig<AppUser, UserRegister>.NewConfig().
                Map(dest=> dest.Password, src=> src.PasswordHash).TwoWays();
            TypeAdapterConfig<AppUser, LoginUserDto>.NewConfig().
                Map(dest => dest.Password, src => src.PasswordHash).TwoWays();


            //////////////////////////////////////////////////////////////////////////
            //TypeAdapterConfig<CartMenuItem, OrderCartDtoRel>.NewConfig().TwoWays();
            //TypeAdapterConfig<MenuItemOrder, OrderCartDtoRel>.NewConfig().TwoWays();
            //TypeAdapterConfig<Cart, AllOrderDto>.NewConfig().TwoWays();
            //TypeAdapterConfig<GetAllCategoriesDto, AddOrderItem>.NewConfig().TwoWays();


        }

    }
}
