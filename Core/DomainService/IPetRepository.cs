using PetShop.Core.Entities;
using PetShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        public List<Pet> ReadPets();

        public Pet AddPet(Pet petToAdd);

        public Pet DeletePet(Pet petToDelete);

        public Pet EditPet(int id, Pet editedPet);

        public List<Pet> SearchByType(PetType type);

        public List<Pet> SearchById(int id);

        public List<Pet> SortPetsByPrice();

        public List<Pet> SearchByTypeAndSortByPrice(PetType type);

    }

}
