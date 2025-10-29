using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Floricultura.Application.ViewModels;


namespace Floricultura.Application.Interfaces
{
public interface IFlorService
{
Task<IEnumerable<FlorViewModel>> GetAllAsync();
Task<FlorViewModel> GetByIdAsync(Guid id);
Task<FlorViewModel> CreateAsync(FlorViewModel model);
Task UpdateAsync(FlorViewModel model);
Task DeleteAsync(Guid id);
}
}