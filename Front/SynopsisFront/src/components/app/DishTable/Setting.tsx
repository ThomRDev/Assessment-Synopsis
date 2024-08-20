import { Button } from "@/components/ui/button"
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"
import { Dish } from "@/interfaces"
import { useStore } from "@/store/store"
import { DotsHorizontalIcon } from "@radix-ui/react-icons"
export const Setting = ({ dish }: { dish : Dish }) => {
  const changeModalIngredients = useStore(state=>state.changeModalIngredients)
  const setDish = useStore(state=>state.setDish)
  return (
    <>
        <DropdownMenu modal={false}>
          <DropdownMenuTrigger asChild>
            <Button variant="ghost" className="h-8 w-8 p-0">
              <span className="sr-only">Open menu</span>
              <DotsHorizontalIcon className="h-4 w-4" />
            </Button>
          </DropdownMenuTrigger>
          <DropdownMenuContent align="end">
            <DropdownMenuLabel>Actions</DropdownMenuLabel>
            <DropdownMenuItem
              onClick={() => {
                changeModalIngredients(true)
                setDish(dish)
              }}
            >
              Show Ingredientes
            </DropdownMenuItem>
            <DropdownMenuSeparator />
            <DropdownMenuItem>Edit Dish</DropdownMenuItem>
            <DropdownMenuItem>Delete Dish</DropdownMenuItem>
          </DropdownMenuContent>
        </DropdownMenu>
    </>
  )
}
