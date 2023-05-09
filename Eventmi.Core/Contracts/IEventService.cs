using Eventmi.Core.Models;

namespace Eventmi.Core.Contracts
{
    public interface IEventService
    {
        Task AddAsync(EventModel model);

        Task DeleteAsync(int id);

        Task UpdateAsync(EventModel model);

        Task<IEnumerable<EventModel>> GetAllAsync();

        Task<EventModel> GetEventAsync(int id);
    }
}
