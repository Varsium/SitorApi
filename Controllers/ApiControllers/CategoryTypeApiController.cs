using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SitorApi.Models.ApiModels;
using SitorApi.Services.ApiServices.Interfaces;

namespace SitorApi.Controllers.ApiControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryTypeApiController : ControllerBase
    {
        private readonly ICategoryTypeApiService _categoryTypeService;

        public CategoryTypeApiController(ICategoryTypeApiService categoryTypeService)
        {
            _categoryTypeService = categoryTypeService;
        }
        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryTypeService.GetCategoryTypeAsync(id);
            return Ok(category);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryTypeService.GetCategoryTypesAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryTypeApi category)
        {
            var createCategory = await _categoryTypeService.CreateCategoryTypeAsync(category);


            return Ok(createCategory);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(CategoryTypeApi category)
        {

            var dbCategory = await _categoryTypeService.UpdateCategoryTypeAsync(category);
            return Ok(dbCategory);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _categoryTypeService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}
