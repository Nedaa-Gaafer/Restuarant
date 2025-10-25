using Mapster;
using Restorant.Application.Contracts;
using Restorant.Application.IServices;
using Restorant.DTOs.CategoryDtos;
using Restorant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryService(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> CreateCategoriesAsync(CreateCategoryDto category)
        {
             var createdCat = category.Adapt<Category>();
             await _categoryRepository.CreateAsync(createdCat);
             var countRow = await  _categoryRepository.SaveChangesAsync();
             return countRow;
        }

        public async Task<int> DeleteCategoriesAsync(int id)
        {
            var foundCat = await _categoryRepository.GetById(id);

            _categoryRepository.DeleteAsync(foundCat);
            var countRow = await _categoryRepository.SaveChangesAsync();
            return countRow;
        }

        public async Task<IEnumerable<GetAllCategoriesDto>> GetAllCategoriesAsync()
        {
            var allCats = await _categoryRepository.GetAllAsync();
            List<GetAllCategoriesDto> res = allCats.Adapt<List<GetAllCategoriesDto>>();
            return res;
        }

        public async  Task<GetAllCategoriesDto> GetCategoryById(int id)
        {
           var foundCat = await _categoryRepository.GetById(id);
            return foundCat.Adapt<GetAllCategoriesDto>();
        }

        public async  Task<int> UpdateCategoriesAsync(GetAllCategoriesDto category)
        {
            var updatedCat = category.Adapt<Category>();
            _categoryRepository.Update(updatedCat);
            var countRow = await _categoryRepository.SaveChangesAsync();
            return countRow;

        }
    }
}
