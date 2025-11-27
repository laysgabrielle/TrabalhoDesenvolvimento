using FloriculturaApp.Application.DTOs;
using FloriculturaApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FloriculturaApp.Presentation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            var categories = await _service.GetAllAsync();
            return View(categories.ToList());
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var category = await _service.GetByIdAsync(id.Value);
            if (category == null)
                return NotFound();

            return View(category);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddAsync(categoryDto);
                    TempData["SuccessMessage"] = "Categoria adicionada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao adicionar a categoria: {ex.Message}");
                }
            }
            return View(categoryDto);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var category = await _service.GetByIdAsync(id.Value);
            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(categoryDto);
                    TempData["SuccessMessage"] = "Categoria atualizada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao atualizar a categoria: {ex.Message}");
                }
            }
            return View(categoryDto);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var category = await _service.GetByIdAsync(id.Value);
            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                TempData["SuccessMessage"] = "Categoria removida com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao remover a categoria: {ex.Message}";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
