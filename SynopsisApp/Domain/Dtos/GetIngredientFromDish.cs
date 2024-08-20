namespace SynopsisApp.Domain.Dtos
{
    public class GetIngredientFromDish
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string IngredientName { get; set; }
        public decimal UnitIngredientPrice { get; set; }
        public decimal TotalPriceIngredient { get; set; }
    }
}
