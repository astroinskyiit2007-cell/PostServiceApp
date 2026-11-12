using PostService.Models;

namespace PostService;

public static class PostingMapper
{
    public static PostingGetDto ToPostingGetDto(Posting posting)
    {
        return new PostingGetDto
        {
            Id = posting.Id,
            Sender = posting.Sender,
            Receiver = posting.Receiver,
            Content = posting.Content,
            Weight = posting.Weight,
            Price = posting.Price
        };
    }
}