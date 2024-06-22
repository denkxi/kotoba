using api.Dtos.Language;
using api.Models;

namespace api.Mappers
{
    public static class LanguageMappers
    {
        public static LanguageDto ToLanguageDto(this Language languageModel)
        {
            return new LanguageDto
            {
                Id = languageModel.Id,
                Name = languageModel.Name,
                LangCode = languageModel.LangCode,
                NativeName = languageModel.NativeName,
                IsCustom = languageModel.IsCustom
            };
        }

        public static Language ToModelFromCreateDto(this CreateLanguageRequestDto languageRequestDto)
        {
            return new Language
            {
                Name = languageRequestDto.Name,
                NativeName = languageRequestDto.NativeName,
                LangCode = languageRequestDto.LangCode
            };
        }
    }
}