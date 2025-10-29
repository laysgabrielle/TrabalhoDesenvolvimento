using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Floricultura.Application.Interfaces;
using Floricultura.Application.ViewModels;
using Floricultura.Domain.Entities;
using Floricultura.Domain.Repositories;


namespace Floricultura.Application.Services
{
public class FlorService : IFlorService
{
private readonly IFlorRepository _repository;


public FlorService(IFlorRepository repository)
{
_repository = repository;
}


public async Task<FlorViewModel> CreateAsync(FlorViewModel model)
{
var entity = new Flor(model.Nome, model.Descricao, model.Preco, model.Estoque);
await _repository.AddAsync(entity);


model.Id = entity.Id;
model.CriadoEm = entity.CriadoEm;
return model;
}


public async Task DeleteAsync(Guid id)
{
await _repository.DeleteAsync(id);
}


public async Task<IEnumerable<FlorViewModel>> GetAllAsync()
{
var list = await _repository.GetAllAsync();
return list.Select(f => new FlorViewModel
{
Id = f.Id,
Nome = f.Nome,
Descricao = f.Descricao,
Preco = f.Preco,
Estoque = f.Estoque,
CriadoEm = f.CriadoEm
});
}


public async Task<FlorViewModel> GetByIdAsync(Guid id)
{
var f = await _repository.GetByIdAsync(id);
if (f == null) return null;
return new FlorViewModel
{
Id = f.Id,
Nome = f.Nome,
Descricao = f.Descricao,
Preco = f.Preco,
Estoque = f.Estoque,
CriadoEm = f.CriadoEm
};
}


public async Task UpdateAsync(FlorViewModel model)
{
var existing = await _repository.GetByIdAsync(model.Id);
if (existing == null) throw new InvalidOperationException("Flor não encontrada");


existing.SetNome(model.Nome);
existing.SetDescricao(model.Descricao);
existing.SetPreco(model.Preco);
existing.SetEstoque(model.Estoque);


await _repository.UpdateAsync(existing);
}
}
}