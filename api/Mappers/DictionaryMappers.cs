using api.Dtos.Dictionary;
using api.Models;

namespace api.Mappers
{
    public static class DictionaryMappers
    {
        public static DictionaryDto ToDictionaryDto(this Dictionary dictionaryModel)
        {
            return new DictionaryDto
            {
                Id = dictionaryModel.Id,
                Name = dictionaryModel.Name,
                SourceLanguage = dictionaryModel.SourceLanguage!.Name,
                TargetLanguage = dictionaryModel.TargetLanguage!.Name
            };
        }

        public static Dictionary ToModelFromCreateDto(this CreateDictionaryRequestDto dictionaryRequestDto)
        {
            return new Dictionary
            {
                Name = dictionaryRequestDto.Name,
                SourceLanguageId = dictionaryRequestDto.SourceLanguageId,
                TargetLanguageId = dictionaryRequestDto.TargetLanguageId
            };
        }
    }
}