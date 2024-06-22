
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Language
{
    public class CreateLanguageRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Language name must be at least 3 characters long")]
        [MaxLength(80, ErrorMessage = "Language name cannot be over 80 characters long")]
        public string Name { get; set; } = string.Empty;

        public string LangCode { get; set; } = string.Empty;

        public string NativeName { get; set; } = string.Empty;
    }
}