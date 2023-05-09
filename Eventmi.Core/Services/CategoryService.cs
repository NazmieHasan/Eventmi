using Eventmi.Core.Contracts;
using Eventmi.Core.Models;
using Eventmi.Infrastructure.Data.Common;
using Eventmi.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventmi.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repo;
        public CategoryService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddAsync(CategoryModel model)
        {
            var entity = new Category()
            {
                Name = model.Name
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }
		
		
        
    }
}
