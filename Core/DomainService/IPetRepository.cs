using PetShop.Core.Entities;
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

        
    }

}
