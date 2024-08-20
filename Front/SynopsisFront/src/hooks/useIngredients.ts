import { Ingredient } from '@/interfaces'
import { getIngredientsFromDish } from '@/services'
import { useQuery } from '@tanstack/react-query'

export const useIngredients = (dishId:number) => {
  const { data, isSuccess, isPending, isError, refetch, isLoading } = useQuery<Ingredient[]>({
    queryKey: ['ingredients'],
    queryFn: async () => await getIngredientsFromDish(dishId),
    refetchOnWindowFocus: false,
    staleTime: 10, // 1 minute,
    retry: 1
  })

  return { ingredients: data, isSuccess, isPending, isError, refetch, isLoading }
}
