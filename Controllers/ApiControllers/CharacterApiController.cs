using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CharacterApiController : ControllerBase
    {

        private readonly ICharacterApiService _characterService;

        public CharacterApiController(ICharacterApiService characterService)
        {
            _characterService = characterService;
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var character = await _characterService.GetCharacterAsync(id);
            return Ok(character);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllCharacters()
        {
            var articles = await _characterService.GetCharactersAsync();
            return Ok(articles);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CharacterApi character)
        {
            var createCharacter = await _characterService.CreateCharacterAsync(character);


            return Ok(createCharacter);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(CharacterApi character)
        {

            var dbArticle = await _characterService.UpdateCharacterAsync(character);
            return Ok(dbArticle);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _characterService.DeleteAsync(id);
            return Ok(isSuccess);
        }

    }
}

