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
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerApiController : ControllerBase
    {
        private readonly IPlayerApiService _playerApiService;

        public PlayerApiController(IPlayerApiService playerApiService)
        {
            _playerApiService = playerApiService;
        }
        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _playerApiService.GetPlayerAsync(id);
            return Ok(category);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _playerApiService.GePlayersAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlayerApi player)
        {
            var createCategory = await _playerApiService.CreatePlayerAsync(player);


            return Ok(createCategory);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(PlayerApi player)
        {

            var dbCategory = await _playerApiService.UpdatePlayerAsync(player);
            return Ok(dbCategory);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _playerApiService.DeleteAsync(id);
            return Ok(isSuccess);
        }
    }
}



