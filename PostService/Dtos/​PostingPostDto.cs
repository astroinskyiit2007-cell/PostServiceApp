namespace PostService;

public class PostingPostDto
{
    public string Sender { get; set; } = string.Empty;
    public string Receiver { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public double Weight { get; set; }
}