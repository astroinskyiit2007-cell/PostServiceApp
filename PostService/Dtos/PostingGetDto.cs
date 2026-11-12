namespace PostService;

public class PostingGetDto
{
    public int Id { get; set; }
    public string Sender { get; set; } = string.Empty;
    public string Receiver { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public double Weight { get; set; }
    public decimal Price { get; set; }
}