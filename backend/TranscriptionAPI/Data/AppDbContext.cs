using Microsoft.EntityFrameworkCore;
using TranscriptionAPI.Model;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Audio> Audios { get; set; } = null!;
    public DbSet<AudioFile> AudioFiles => Set<AudioFile>();
    public DbSet<Transcription> Transcriptions => Set<Transcription>();
    public DbSet<UserActionLog> UserActionLogs => Set<UserActionLog>();
    public DbSet<Log> Logs { get; set; }

}

