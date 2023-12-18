using System.ComponentModel.DataAnnotations;

namespace Gallery.Models
{
    public class Images
    {
        public int Id { get; set; }
        public string? ImageUrl {  get; set; }
        public string? Description { get; set; }
        public DateTime Timestamp { get; set; }
        public string? Rendertime { get; set; }
        public string? Blurhash64 { get; set; }

    }
}
