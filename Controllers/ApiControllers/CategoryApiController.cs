using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SitorApi.Models.ApiModels;
using SitorApi.Models.DbModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Controllers.ApiControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {

        private readonly ICategoryApiService _categoryService;

        public CategoryApiController(ICategoryApiService categoryService)
        {
            _categoryService = categoryService;
        }
        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryService.GetCategoryAsync(id);
            return Ok(category);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryApi category)
        {
            var createCategory = await _categoryService.CreateCategoryAsync(category);


            return Ok(createCategory);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(CategoryApi category)
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


