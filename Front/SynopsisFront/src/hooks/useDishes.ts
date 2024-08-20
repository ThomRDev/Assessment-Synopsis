import { Dish } from "@/interfaces"
import { getDishes } from "@/services"
import { useQuery } from "@tanstack/react-query"

export const useDishes = () => {
  const { data, isSuccess, isPending, isError, refetch, isLoading } = useQuery<Dish[]>({
    queryKey: ['dishes'],
    queryFn: async () => await getDishes(),
    refetchOnWindowFocus: false,
    staleTime: 1000 * 60, // 1 minute,
    retry: 1
  })

  return { dishes: data, isSuccess, isPending, isError, refetch, isLoading }
}
