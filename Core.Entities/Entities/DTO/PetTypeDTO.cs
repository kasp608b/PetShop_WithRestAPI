using System.Collections.Generic;
using PetShop.Core.Entities.Entities.Business;

namespace PetShop.Core.Entities.Entities.DTO
{
    public class PetTypeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Pet> Pets { get; set; }

        public override string ToString()
        {
            return $"ID = {ID.ToString()}, Name = {Name.ToString()}\n";
        }
    }
}