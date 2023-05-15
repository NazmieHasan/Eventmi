using Eventmi.Core.Contracts;
using Eventmi.Core.Models;
using Eventmi.Infrastructure.Data;
using Eventmi.Infrastructure.Data.Common;
using Eventmi.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventmi.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository repo;

        private readonly EventmiDbContext context;

        public EventService(IRepository _repo,
            EventmiDbContext _context)
        {
            repo = _repo;
            context = _context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task AddAsync(EventModel model)
        {
            var entity = new Event()
            {
                Name = model.Name,
                End = model.End,
                Place = model.Place,
                Start = model.Start,
                CategoryId = model.Category
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await repo.DeleteAsync<Event>(id);

            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventModel>> GetAllAsync()
        {
            var entities = await context.Events
                .Include(e => e.Category)
                .ToListAsync();

            return entities
                .Select(e => new EventModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    End = e.End,
                    Place = e.Place,
                    Start = e.Start,
                    Category = e.CategoryId
                });
        }

        public async Task<EventModel> GetEventAsync(int id)
        {
            var entity = await repo.GetByIdAsync<Event>(id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid id", nameof(id));
            }

            return new EventModel() 
            {
                Name = entity.Name,
                End = entity.End,
                Place = entity.Place,
                Start = entity.Start,
                Id = entity.Id,
                Category = entity.CategoryId
            };
        }

        public async Task UpdateAsync(EventModel model)
        {
            var entity = await repo.GetByIdAsync<Event>(model.Id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid id", nameof(model.Id));
            }

            entity.End = model.End;
            entity.Place = model.Place;
            entity.Start = model.Start;
            entity.Name = model.Name;

            await repo.SaveChangesAsync();
        }
    }
}
