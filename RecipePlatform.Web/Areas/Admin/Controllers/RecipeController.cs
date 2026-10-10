using Microsoft.AspNetCore.Mvc;
using RecipePlatform.Application.Interfaces;
using RecipePlatform.Core.Entities;

namespace RecipePlatform.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: Admin/Recipes
        public async Task<IActionResult> Index()
        {
            var recipes = await _recipeService.GetAllAsync();
            return View(recipes);
        }

        // GET: Admin/Recipes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var recipe = await _recipeService.GetByIdAsync(id);
            if (recipe == null) return NotFound();
            return View(recipe); // podtverzhdnie
        }

        // POST: Admin/Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _recipeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
