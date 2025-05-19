public class UserActionLog
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int AudioFileId { get; set; }
    public string ActionType { get; set; } = string.Empty; // dinle, düzenle, vs.
    public DateTime Timestamp { get; set; } = DateTime.Now;
}

