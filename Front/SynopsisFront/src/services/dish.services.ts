import { Dish, Ingredient } from "@/interfaces"

const API_BASE_URL = import.meta.env.VITE_API_RESTAURANT_BASE_URL

export const getDishes = async () => {
  const response = await fetch(`${API_BASE_URL}/Dish`, {
    headers: {
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    }
  }).then(res=>res.json())
  return response as Dish[]
}

export const getIngredientsFromDish = async (dishId: number) => {
  const response = await fetch(`${API_BASE_URL}/Dish/${dishId}`, {
    headers: {
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    }
  }).then(res=>res.json())
  return response as Ingredient[]
}