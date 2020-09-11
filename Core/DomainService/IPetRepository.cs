using PetShop.Core.Entities;
using PetShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entities.Entities;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        public List<Pet> GetAllPets();

        public FilteredList<Pet> GetAllPetsFiltered(Filter filter);

        public Pet AddPet(Pet petToAdd);

        public Pet DeletePet(Pet petToDelete);

        public Pet EditPet(int id, Pet editedPet);

        public List<Pet> SearchById(int id);


    }

}
