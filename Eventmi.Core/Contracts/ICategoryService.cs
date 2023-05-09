using Eventmi.Core.Models;

namespace Eventmi.Core.Contracts
{
    public interface ICategoryService
    {
        Task AddAsync(CategoryModel model);
    }
}
