using PostService.Dtos;

namespace PostService;

public interface IPostingsService
{
    IEnumerable<PostingGetDto> GetAll();
    PostingGetDto? GetById(int id);
    PostingGetDto Create(PostingPostDto dto);
    PostingGetDto? Update(int id, PostingPutDto dto);
    bool Delete(int id);
}