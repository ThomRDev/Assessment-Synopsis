using SynopsisApp.Domain.Models;

namespace SynopsisApp.Domain.Repositories
{
    public interface DishRepository
    {
        public Task<List<Dish>> GetDishes();
    }
}
