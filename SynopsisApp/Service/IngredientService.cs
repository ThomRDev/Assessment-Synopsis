using SynopsisApp.Domain.Dtos;

namespace SynopsisApp.Service
{
    public interface IngredientService
    {
        public Task<List<GetIngredientFromDish>> GetIngredientsFromDish(int dishId);
     }
}
