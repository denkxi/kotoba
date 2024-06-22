using api.Dtos.Language;

namespace api.Dtos.Dictionary
{
    public class DictionaryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string SourceLanguage { get; set; } = string.Empty;
        public string TargetLanguage { get; set; } = string.Empty;
    }
}