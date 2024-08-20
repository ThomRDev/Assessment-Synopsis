import { useIngredients } from "@/hooks/useIngredients";

export const IngredientContent = ({ dishId }: { dishId: number }) => {
  const { ingredients, isLoading, isError } = useIngredients(dishId);
  return (
    <div>
      {isError && <p>Error fetching ingredients.</p>}
      
      {isLoading && <p>Cargando ...</p>}

      {!isLoading && (
        <ul className="list-disc pl-5">
          {
            ingredients?.length ? <>
            {ingredients?.map(ingredient => (
            <li key={ingredient.id}>
              {ingredient.ingredientName} - Quantity: {ingredient.quantity} - Price: ${ingredient.unitIngredientPrice} - Total Price: ${ingredient.totalPriceIngredient}
            </li>
          ))}
            </> : <div>Sin informacion que mostrar</div>
          }
        </ul>
      )}
    </div>
  );
};