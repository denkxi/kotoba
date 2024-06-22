using api.Dtos.Dictionary;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/dictionary")]
    [ApiController]
    public class DictionaryController : ControllerBase
    {
        private readonly IDictionaryRepository _dictRepo;

        public DictionaryController(IDictionaryRepository dictRepo)
        {
            _dictRepo = dictRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] DictionaryQueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dictionaries = await _dictRepo.GetAllAsync(query);

            var dictionariesDto = dictionaries.Select(l => l.ToDictionaryDto()).ToList();

            return Ok(dictionariesDto);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dictionary = await _dictRepo.GetByIdAsync(id);

            if (dictionary == null)
            {
                return NotFound();
            }

            return Ok(dictionary.ToDictionaryDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDictionaryRequestDto dictionaryRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dictionaryModel = dictionaryRequestDto.ToModelFromCreateDto();

            await _dictRepo.CreateAsync(dictionaryModel);

            return CreatedAtAction(nameof(GetById), new { id = dictionaryModel.Id }, dictionaryModel.ToDictionaryDto());
        }
    }
}