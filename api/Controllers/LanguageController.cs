using api.Dtos.Language;
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

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var language = await _langRepo.GetByIdAsync(id);

            if (language == null)
            {
                return NotFound();
            }

            return Ok(language.ToLanguageDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLanguageRequestDto languageRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var languageModel = languageRequestDto.ToModelFromCreateDto();

            await _langRepo.CreateAsync(languageModel);

            return CreatedAtAction(nameof(GetById), new { id = languageModel.Id }, languageModel.ToLanguageDto());
        }
    }
}