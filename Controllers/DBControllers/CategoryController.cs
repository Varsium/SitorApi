using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SitorApi.Models.DbModels;
using SitorApi.Services.DbServices.Interfaces;

namespace SitorApi.Controllers.DBControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
      //  [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryService.GetCategoryAsync(id);
            return Ok(category);
        }
    //    [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories =await _categoryService.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            var createCategory =await _categoryService.CreateCategoryAsync(category);


            return Ok(createCategory);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(Category category)
        {

            var dbCategory = await _categoryService.UpdateCategoryAsync(category);
            return Ok(dbCategory);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _categoryService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}

