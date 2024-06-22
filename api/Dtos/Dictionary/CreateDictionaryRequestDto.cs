using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Dictionary
{
    public class CreateDictionaryRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Dictionary name should be at least 5 characters long")]
        [MaxLength(80, ErrorMessage = "Dictionary name cannot be over 80 characters long")]
        public string Name { get; set; } = string.Empty;
        [Required]
        public Guid SourceLanguageId { get; set; }
        [Required]
        public Guid TargetLanguageId { get; set; }
    }
}