public class GetBookDto
{
    public int id { get; set; }
    public string title { get; set; }
    public DateOnly publish_date { get; set; }
    public string genre { get; set; }
    public decimal price { get; set; }
}