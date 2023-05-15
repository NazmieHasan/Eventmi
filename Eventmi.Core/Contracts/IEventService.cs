using Eventmi.Core.Models;
using Eventmi.Infrastructure.Data.Models;

namespace Eventmi.Core.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task AddAsync(EventModel model);

        Task DeleteAsync(int id);

        Task UpdateAsync(EventModel model);

        Task<IEnumerable<EventModel>> GetAllAsync();

        Task<EventModel> GetEventAsync(int id);
    }
}
