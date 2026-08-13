using System.ComponentModel.DataAnnotations;

namespace SecureApi.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(5000)]
        public string Content { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;
    }
}