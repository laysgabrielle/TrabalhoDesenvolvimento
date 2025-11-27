using FloriculturaApp.Application.DTOs;
using FloriculturaApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FloriculturaApp.Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var products = await _service.GetAllAsync();
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories;
            return View(products.ToList());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _service.GetByIdAsync(id.Value);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // GET: Product/Create
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories;
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,CategoryId")] ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddAsync(productDto);
                    TempData["SuccessMessage"] = "Flor adicionada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao adicionar a flor: {ex.Message}");
                }
            }

            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories;
            return View(productDto);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _service.GetByIdAsync(id.Value);
            if (product == null)
                return NotFound();

            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories;
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,CategoryId")] ProductDto productDto)
        {
            if (id != productDto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(productDto);
                    TempData["SuccessMessage"] = "Flor atualizada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Erro ao atualizar a flor: {ex.Message}");
                }
            }

            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories;
            return View(productDto);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _service.GetByIdAsync(id.Value);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                TempData["SuccessMessage"] = "Flor removida com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao remover a flor: {ex.Message}";
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Search
        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Query não pode estar vazia");

            var results = await _service.SearchAsync(query);
            return PartialView("_ProductList", results.ToList());
        }
    }
}
