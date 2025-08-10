namespace URLShortener.Models
{
    public class URLMapping
    {
        public int Id { get; set; }              // Primary key
        public string OriginalUrl { get; set; } // The long URL
        public string ShortCode { get; set; }   // The shortened code
        public int AccessCount { get; set; }    // How many times it was accessed
        public DateTime CreatedAt { get; set; }
        public DateTime? LastAccessedAt { get; set; }  // When was this short URL last used

    }
}
