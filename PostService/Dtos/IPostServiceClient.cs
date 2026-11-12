using System.Collections.Generic;
using System.Threading.Tasks;
using PostService.Dtos;

namespace PostService.App
{
    public interface IPostServiceClient
    {
        Task<List<PostingGetDto>> GetAllAsync();
        Task<PostingGetDto?> GetByIdAsync(int id);
        Task<PostingGetDto?> CreateAsync(PostingPostDto dto);
        Task UpdateAsync(int id, PostingPutDto dto);
        Task DeleteAsync(int id);
    }
}