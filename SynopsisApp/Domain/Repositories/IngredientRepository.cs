using SynopsisApp.Domain.Models;

namespace SynopsisApp.Domain.Repositories
{
    public interface IngredientRepository
    {
        public Task<List<Ingredient>> GetIngredientFromDish(int dish_id);
    }
}
