namespace BTSession03.Models
{
    public class Clother
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceReduce { get; set; }
        public string ImageUrl { get; set; }
        
        public int CategoryClotherId { get; set; }
        public CategoryClother CategoryClother { get; set; }
    }
}