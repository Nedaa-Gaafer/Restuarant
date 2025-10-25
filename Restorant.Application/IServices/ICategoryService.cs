using Restorant.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Application.IServices
{
    public interface ICategoryService
    {
        public Task<IEnumerable<GetAllCategoriesDto>> GetAllCategoriesAsync();
        public Task<int> CreateCategoriesAsync(CreateCategoryDto category);

        public Task<int> UpdateCategoriesAsync(GetAllCategoriesDto category);

        public Task<int> DeleteCategoriesAsync(int id);

        public Task<GetAllCategoriesDto> GetCategoryById(int id);
    }
}
