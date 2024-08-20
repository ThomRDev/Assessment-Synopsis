import { DishTable } from './components/app/DishTable/DihsTable'
import { IngredientModal } from './components/app/Ingredient/IngredientModal'

function App() {

  return (
    <div className='w-[1040px] mx-auto'>
      <DishTable />
      <IngredientModal />
    </div>
  )
}

export default App
