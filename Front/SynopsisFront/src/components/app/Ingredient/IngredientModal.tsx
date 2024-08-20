import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog"
import { IngredientContent } from "./IngredientContent"
import { useStore } from "@/store/store"
export const IngredientModal = () => {
  const open = useStore(state=>state.openIngredients)
  const changeModalIngredients = useStore(state=>state.changeModalIngredients)
  const dish = useStore(state => state.currentDishFocus)
  const setDish = useStore(state => state.setDish)

  if(!dish?.id) return;

  return (
    <Dialog open={open} onOpenChange={val=>{
      changeModalIngredients(val)
      if(val == false) {
        setDish(null)
      }
    }} >
      <DialogContent className="sm:max-w-[425px]">
        <DialogHeader>
          <DialogTitle>Ingredients - {dish.name}</DialogTitle>
          <DialogDescription>
            {dish.description}
          </DialogDescription>
        </DialogHeader>
        {
          <IngredientContent dishId={dish!.id} />
        }
      </DialogContent>
    </Dialog>
  )
}
