namespace SynopsisApp.Domain.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DishPrice { get; set; }
        public int DishTypeId { get; set; }
        public string DishTypeName { get; set; }
    }
}
