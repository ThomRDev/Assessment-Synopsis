import { Dish } from "@/interfaces";
import { create } from "zustand";

type State = {
  openIngredients: boolean;
  currentDishFocus?: Dish | null
}

type Actions = {
  changeModalIngredients: (value:boolean) => void;
  setDish:(value?:Dish | null) => void
}

export const useStore = create<State & Actions>()(
  (set) => {
    return {
      openIngredients: false,
      currentDishFocus : null,
      changeModalIngredients : (value) => {
        set({
          openIngredients: value
        })
      },
      setDish : (value) => {
        set({
          currentDishFocus : value
        })
      }
    }
  }
);