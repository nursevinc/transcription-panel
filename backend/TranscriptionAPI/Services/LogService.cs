using TranscriptionAPI.Data;
using TranscriptionAPI.Model;

public class LogService
{
    private readonly AppDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LogService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task LogAsync(string action)
    {
        try
        {
            var username = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Unknown";

            var log = new Log
            {
                Username = username,
                Action = action,
                Timestamp = DateTime.UtcNow
            };

            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task LogAction(string userId, string action)
    {
        var log = new Log
        {
            Username = userId,
            Action = action,
            Timestamp = DateTime.UtcNow
        };

        _context.Logs.Add(log);
        await _context.SaveChangesAsync();
    }


}
