using System.Collections.Generic;

namespace BTSession03.Models
{
    public class CategoryClother
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Clother> Clothers { get; set; }
    }
}