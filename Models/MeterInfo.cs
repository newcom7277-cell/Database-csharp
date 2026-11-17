namespace metermngemen.Models;

public class MeterInfo
{
     public int Id { get; set; }
    public string SerialNumber { get; set; } = string.Empty;
    public decimal CurrentReading { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Location { get; set; }
}