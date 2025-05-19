using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranscriptionAPI.Data;
using TranscriptionAPI.Model;

namespace TranscriptionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Token zorunlu
    public class AudioController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly LogService _logService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AudioController(AppDbContext context, LogService logService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _logService = logService;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        public async Task<IActionResult> GetAudios()
        {
            var audios = await _context.Audios.ToListAsync();
            return Ok(audios);
        }

        [HttpPost]
        public async Task<IActionResult> AddAudio([FromBody] Audio newAudio)
        {
            if (string.IsNullOrWhiteSpace(newAudio.FileName) || string.IsNullOrWhiteSpace(newAudio.FilePath))
            {
                return BadRequest("Dosya adı ve yolu boş olamaz.");
            }

            newAudio.UploadDate = DateTime.UtcNow;

            _context.Audios.Add(newAudio);
            await _context.SaveChangesAsync();

            return Ok(newAudio);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Dosya seçilmedi.");

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "NewFolder1");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var audio = new Audio
            {
                FileName = file.FileName,
                FilePath = $"/NewFolder1/{file.FileName}",
                UploadDate = DateTime.Now
            };

            _context.Audios.Add(audio);
            await _context.SaveChangesAsync();

            return Ok(audio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTranscription(int id, [FromBody] Audio updatedAudio)
        {
            var existingAudio = await _context.Audios.FindAsync(id);
            if (existingAudio == null)
                return NotFound();

            existingAudio.Transcription = updatedAudio.Transcription;

            _context.Audios.Update(existingAudio);
            await _context.SaveChangesAsync();

            // Burada log ekle
            await _logService.LogAsync($"Transkripsiyon güncellendi. AudioId: {id}");

            return Ok(existingAudio);
        }
        [HttpPost("testlog")]
        public async Task<IActionResult> TestLog()
        {
            await _logService.LogAsync("Test log kaydı.");
            return Ok("Log kaydedildi.");
        }

    }
}

