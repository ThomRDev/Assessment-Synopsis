using SynopsisApp.Config;
using SynopsisApp.Domain.Models;
using System.Data;

namespace SynopsisApp.Domain.Repositories.impl
{
    public class IngredientRepositoryImpl : IngredientRepository
    {
        private readonly ISqlConnectionWrapper _sqlConnectionWrapper;

        public IngredientRepositoryImpl(ISqlConnectionWrapper sqlConnectionWrapper)
        {
            _sqlConnectionWrapper = sqlConnectionWrapper;
        }
        public async Task<List<Ingredient>> GetIngredientFromDish(int dish_id)
        {
            try
            {
                await _sqlConnectionWrapper.OpenAsync();

                var command = _sqlConnectionWrapper.CreateCommand();
                command.SetCommandText("GET_INGREDIENTS_FROM_DISH");
                command.SetCommandType(CommandType.StoredProcedure);

                command.AddParameterWithValue("@dish_id", dish_id);

                var ingredients = new List<Ingredient>();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var ingredient = new Ingredient
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
                            IngredientName = reader.GetString(reader.GetOrdinal("ingredient_name")),
                            UnitIngredientPrice = reader.GetDecimal(reader.GetOrdinal("unitIngredient")),
                            TotalPriceIngredient = reader.GetDecimal(reader.GetOrdinal("totalPriceIngrediente"))
                        };
                        ingredients.Add(ingredient);
                    }
                }

                return ingredients;
            }
            finally
            {
                await _sqlConnectionWrapper.CloseAsync();
            }
        }
    }
}
