using Microsoft.AspNetCore.Http;

namespace BLL.Services.ImportServices
{
    public interface IImporter<T> where T : class
    {
        Task<IEnumerable<T>> Import(IFormFile file);
    }
}
