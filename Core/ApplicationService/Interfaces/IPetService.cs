using PetShop.Core.Entities;
using PetShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        public List<Pet> GetPets();

        public Pet AddPet(string name, PetType type, DateTime birthdate, DateTime soldDate, string color, string previousOwner, double price);

        public Pet DeletePet(int id);

        public Pet EditPet(int id, string name, PetType type, DateTime birthdate, DateTime soldDate, string color, string previousOwner, double price);

        public List<Pet> SearchByType(PetType type);

        public List<Pet> SortPetsByPrice();
    }
}
