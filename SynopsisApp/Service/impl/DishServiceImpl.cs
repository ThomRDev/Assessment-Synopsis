using SynopsisApp.Domain.Dtos;
using SynopsisApp.Domain.Repositories;

namespace SynopsisApp.Service.impl
{
    public class DishServiceImpl : DishService
    {
        public readonly DishRepository _dishRepository;

        public DishServiceImpl(DishRepository dishRepository) 
        {
            this._dishRepository = dishRepository;
        }

        public async Task<List<GetDishDto>> GetDishes()
        {
            var dishes = await _dishRepository.GetDishes();

            return dishes.Select(dish => new GetDishDto 
            { 
                Id = dish.Id, 
                Name = dish.Name,
                Description = dish.Description,
                DishPrice = dish.DishPrice,
                DishTypeId = dish.DishTypeId,
                DishTypeName = dish.DishTypeName
            }).ToList();
        }
    }
}
