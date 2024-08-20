import { DataTable } from './data-table'
import { columns } from './columns'
import { useDishes } from '@/hooks'
import { Dish } from '@/interfaces'

export const DishTable = () => {
  const { dishes, isLoading, isError } = useDishes()

  if(isLoading) return (
    <>
      <div>Cargando ...</div>
    </>
  )

  if( isError) return (
    <>
      <div>Ocurrio un error ...</div>
    </>
  )

  console.log({dishes})

  return (
    <div className="container mx-auto py-10">
      <DataTable columns={columns} data={dishes as Dish[]} />
    </div>
  )
}
