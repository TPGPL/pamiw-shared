using PamiwShared.Models;

namespace PamiwShared.Services;

public interface IAuthorService
{
    Task<ServiceResponse<List<Author>>> GetAuthorsAsync();
    Task<ServiceResponse<Author>> GetAuthorAsync(int id);
    Task<ServiceResponse<Author>> CreateAuthorAsync(Author author);
    Task<ServiceResponse<Author>> UpdateAuthorAsync(int id, Author author);
    Task<ServiceResponse<Author>> DeleteAuthorAsync(int id);
}
