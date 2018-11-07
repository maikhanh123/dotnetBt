namespace BTSession03.Models
{
    public class Electronic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceReduce { get; set; }
        public string Imageurl { get; set; }
        public int CategoryElectronicId { get; set; }
        public CategoryElectronic CategoryElectronic { get; set; }
    }
}