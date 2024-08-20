export interface Dish {
  id:           number;
  name:         string;
  description:  string;
  dishPrice:    number;
  dishTypeId:   number;
  dishTypeName: string;
}

export interface Ingredient {
  id:                   number;
  quantity:             number;
  ingredientName:       string;
  unitIngredientPrice:  number;
  totalPriceIngredient: number;
}