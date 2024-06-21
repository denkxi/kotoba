using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/language")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageRepository _langRepo;

        public LanguageController(ILanguageRepository langRepo)
        {
            _langRepo = langRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] LanguageQueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var languages = await _langRepo.GetAllAsync(query);

            var languagesDto = languages.Select(l => l.ToLanguageDto()).ToList();

            return Ok(languagesDto);
        }
    }
}