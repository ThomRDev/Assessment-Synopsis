
import { ColumnDef, SortDirection, FilterFn, Row } from "@tanstack/react-table"
import { Checkbox } from "@/components/ui/checkbox";
import { Button } from "@/components/ui/button"

import {
  ChevronDownIcon,
  ChevronUpIcon,
} from "@radix-ui/react-icons";
import { Dish } from "@/interfaces";
import { Setting } from "./Setting";

const SortedIcon = ({ isSorted }: { isSorted: false | SortDirection }) => {
  if (isSorted === "asc") {
    return <ChevronUpIcon className="h-4 w-4" />;
  }

  if (isSorted === "desc") {
    return <ChevronDownIcon className="h-4 w-4" />;
  }

  return null;
};

const myCustomFilterFn: FilterFn<Dish> = (
  row: Row<Dish>,
  columnId: string,
  filterValue: string
) => {
  filterValue = filterValue.toLowerCase();

  const filterParts = filterValue.split(" ");
  const rowValues =
    `${row.original.description} ${row.original.dishTypeName} ${row.original.name}`.toLowerCase();

  return filterParts.every((part) => rowValues.includes(part));
};

export const columns: ColumnDef<Dish>[] = [

  {
    id: "select",
    header: ({ table }) => (
      <Checkbox
        checked={
          table.getIsAllPageRowsSelected() ||
          (table.getIsSomePageRowsSelected() && "indeterminate")
        }
        onCheckedChange={(value) => table.toggleAllPageRowsSelected(!!value)}
        aria-label="Select all"
      />
    ),
    cell: ({ row }) => (
      <Checkbox
        checked={row.getIsSelected()}
        onCheckedChange={(value) => row.toggleSelected(!!value)}
        aria-label="Select row"
      />
    ),
    enableSorting: false,
    enableHiding: false,
  },
  {
    accessorKey: "dishTypeName",
    header: ({ column }) => {
      return (
        <Button
          variant="ghost"
          onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
        >
          Dish Type
          <SortedIcon isSorted={column.getIsSorted()} />
        </Button>
      );
    },
    cell: ({ row }) => {
      const dishTypeName = row.getValue("dishTypeName") as string;
      // const variant =
      //   {
      //     pending: "secondary",
      //     processing: "info",
      //     success: "success",
      //     failed: "destructive",
      //   }[status] ?? ("default" as any);

      return (
        <div>
          { dishTypeName }
        </div>
      );
    },
  },
  {
    accessorKey: "name",
    // solo a este porque en el onchange del input solo usamos el email
    filterFn: myCustomFilterFn,
    // header: "Email",
    header: ({ column }) => {
      return (
        <Button
          variant="ghost"
          onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
        >
          Dish Name
          <SortedIcon isSorted={column.getIsSorted()} />
        </Button>
      );
    }
  },
  {
    accessorKey: "dishPrice",
    // header: "Amount",
    // header: () => <div className="text-right">Amount</div>,
    header: ({ column }) => {
      return (
        <div className="text-right">
          <Button
            variant="ghost"
            onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
          >
            Dish Price
            <SortedIcon isSorted={column.getIsSorted()} />
          </Button>
        </div>
      );
    },
    cell: ({ row }) => {
      const amount = parseFloat(row.getValue("dishPrice"))
      const formatted = new Intl.NumberFormat("en-US",{
        style: "currency",
        currency: "USD"
      }).format(amount);

      return <div className="text-right font-medium">{ formatted }</div>
    }
  },
{
  
  accessorKey: "description",
  // solo a este porque en el onchange del input solo usamos el email
  // header: "Email",
  header: ({ column }) => {
    return (
      <Button
        variant="ghost"
        onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
      >
        Dish Description
        <SortedIcon isSorted={column.getIsSorted()} />
      </Button>
    );
  }
},

  // Row Actions
  // https://ui.shadcn.com/docs/components/data-table
  // no requiere de header, por lo tanto se necesita un ud
  {
    id: "actions",
    cell: ({ row }) => {
      const dish = row.original
      return (
        <Setting dish={dish}  />
      )
    },
  },
]

// ejemplo del lado del servidor
// https://tanstack.com/table/latest/docs/framework/react/examples/pagination-controlled
// cuando va la siguiente pagina haga la peticion http
// usa el tanstack table y tanstack query