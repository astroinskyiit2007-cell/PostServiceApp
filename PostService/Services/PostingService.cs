using PostService.Dtos;
using PostService.Mappings;
using PostService.Models;

namespace PostService;

public class PostingsService : IPostingsService
{
    private readonly List<Posting> _postings = new()
    {
        new Posting { Id = 1, Sender = "Олександр", Receiver = "Марія", Content = "Лист", Weight = 0.5, Price = 25m },
        new Posting { Id = 2, Sender = "Іван", Receiver = "Петро", Content = "Посилка", Weight = 1.2, Price = 60m }
    };

    public IEnumerable<PostingGetDto> GetAll()
    {
        return _postings.Select(PostingMapper.ToPostingGetDto);
    }

    public PostingGetDto? GetById(int id)
    {
        var posting = _postings.FirstOrDefault(p => p.Id == id);
        return posting is null ? null : PostingMapper.ToPostingGetDto(posting);
    }

    public PostingGetDto Create(PostingPostDto dto)
    {
        var posting = new Posting
        {
            Id = _postings.Count > 0 ? _postings.Max(p => p.Id) + 1 : 1,
            Sender = dto.Sender,
            Receiver = dto.Receiver,
            Content = dto.Content,
            Weight = dto.Weight,
            Price = (decimal)dto.Weight * 50m
        };

        _postings.Add(posting);
        return PostingMapper.ToPostingGetDto(posting);
    }

    public PostingGetDto? Update(int id, PostingPutDto dto)
    {
        var posting = _postings.FirstOrDefault(p => p.Id == id);
        if (posting is null) return null;

        posting.Sender = dto.Sender;
        posting.Receiver = dto.Receiver;
        posting.Content = dto.Content;
        posting.Weight = dto.Weight;
        posting.Price = dto.Price;

        return PostingMapper.ToPostingGetDto(posting);
    }

    public bool Delete(int id)
    {
        var posting = _postings.FirstOrDefault(p => p.Id == id);
        if (posting is null) return false;

        _postings.Remove(posting);
        return true;
    }
}