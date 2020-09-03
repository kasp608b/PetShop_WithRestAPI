using PetShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entities.Entities
{
    public class Filter
    {
        
        public bool IsSort { get; set; }

        public PetType SearchType { get; set; }

        public int SearchId { get; set; }
    }
}
