using SynopsisApp.Domain.Dtos;
using SynopsisApp.Domain.Repositories;

namespace SynopsisApp.Service.impl
{
    public class IngredientServiceImpl : IngredientService
    {

        public readonly IngredientRepository _ingredientRepository;
        public IngredientServiceImpl(IngredientRepository ingredientRepository) 
        {
            this._ingredientRepository = ingredientRepository;
        }

        public async Task<List<GetIngredientFromDish>> GetIngredientsFromDish(int dishId)
        {
            return (await this._ingredientRepository.GetIngredientFromDish(dishId)).Select(
                        ing => new GetIngredientFromDish
                        {
                            Id = ing.Id,
                            Quantity = ing.Quantity,
                            IngredientName = ing.IngredientName,
                            UnitIngredientPrice = ing.UnitIngredientPrice,
                            TotalPriceIngredient = ing.TotalPriceIngredient
                        }
                    ).ToList();

        }
    }
}
