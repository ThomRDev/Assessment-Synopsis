using SynopsisApp.Domain.Dtos;

namespace SynopsisApp.Service
{
    public interface DishService
    {
        public Task<List<GetDishDto>> GetDishes();
    }
}
