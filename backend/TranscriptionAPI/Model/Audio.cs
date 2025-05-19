namespace TranscriptionAPI.Model

{
    public class Audio
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public DateTime UploadDate { get; set; } = DateTime.UtcNow;
        public string? Transcription { get; set; }
    }
}

