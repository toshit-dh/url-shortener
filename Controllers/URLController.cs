using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using URLShortener.Data;
using URLShortener.Models;

namespace URLShortener.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class URLController : ControllerBase
    {
        private readonly URLDBContext _context;

        public URLController(URLDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateShortUrl([FromBody] string originalUrl)
        {
            if (!Uri.IsWellFormedUriString(originalUrl, UriKind.Absolute))
                return BadRequest("Invalid URL");

            var shortCode = GenerateShortCode();

            while (await _context.UrlMappings.AnyAsync(u => u.ShortCode == shortCode))
            {
                shortCode = GenerateShortCode();
            }

            var urlMapping = new URLMapping
            {
                OriginalUrl = originalUrl,
                ShortCode = shortCode,
                AccessCount = 0,
                CreatedAt = DateTime.UtcNow
            };

            _context.UrlMappings.Add(urlMapping);
            await _context.SaveChangesAsync();

            return Ok(new { shortUrl = $"{Request.Scheme}://{Request.Host}/{shortCode}" });
        }

        [HttpGet("{shortCode}")]
        public async Task<IActionResult> RedirectToOriginal(string shortCode)
        {
            var mapping = await _context.UrlMappings.FirstOrDefaultAsync(u => u.ShortCode == shortCode);

            if (mapping == null)
                return NotFound();

            mapping.AccessCount++;
            mapping.LastAccessedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return Redirect(mapping.OriginalUrl);
        }

        private string GenerateShortCode()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
