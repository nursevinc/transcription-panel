public class Transcription
{
    public int Id { get; set; }
    public int AudioFileId { get; set; }
    public string Text { get; set; } = string.Empty;

    public AudioFile? AudioFile { get; set; }
}

