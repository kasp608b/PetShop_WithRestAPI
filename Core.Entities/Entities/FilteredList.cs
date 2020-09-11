using System.Collections.Generic;

namespace PetShop.Core.Entities.Entities
{
    public class FilteredList<T>
    {
        public Filter FilterUsed { get; set; }
        public int TotalCount { get; set; }
        public List<T> List { get; set; }
    }
}