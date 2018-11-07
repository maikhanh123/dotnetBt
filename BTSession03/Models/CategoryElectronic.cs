using System.Collections.Generic;

namespace BTSession03.Models
{
    public class CategoryElectronic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Electronic> Electronics { get; set; }
    }
}