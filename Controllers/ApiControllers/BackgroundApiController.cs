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
    public class BackgroundApiController : ControllerBase
    {
        private readonly IBackgroundApiService _backgroundApiService;

        public BackgroundApiController(IBackgroundApiService backgroundApiService)
        {
            _backgroundApiService = backgroundApiService;
        }
        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]

        public async Task<IActionResult> Get(int id)
        {
            var backgroundApi = await _backgroundApiService.GetBackgroundAsync(id);
            return Ok(backgroundApi);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllBackgroundApis()
        {
            var articles = await _backgroundApiService.GetBackgroundsAsync();
            return Ok(articles);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BackgroundApi backgroundApi)
        {
            var createBackgroundApi = await _backgroundApiService.CreateBackground(backgroundApi);


            return Ok(createBackgroundApi);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(BackgroundApi backgroundApi)
        {

            var dbBackgroundApi = await _backgroundApiService.UpdateBackgroundAsync(backgroundApi);
            return Ok(dbBackgroundApi);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _backgroundApiService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}

