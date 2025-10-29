using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Floricultura.Domain.Entities;


namespace Floricultura.Domain.Repositories
{
public interface IFlorRepository
{
Task<Flor> GetByIdAsync(Guid id);
Task<IEnumerable<Flor>> GetAllAsync();
Task AddAsync(Flor flor);
Task UpdateAsync(Flor flor);
Task DeleteAsync(Guid id);
}
}