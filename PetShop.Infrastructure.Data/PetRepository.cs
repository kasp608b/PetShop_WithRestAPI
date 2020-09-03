using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using PetShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        public List<Pet> ReadPets()
        {
            return FakeDB._pets;
        }
        public Pet AddPet(Pet petToAdd)
        {
            return FakeDB.AddPet(petToAdd);
        }

        public Pet DeletePet(Pet petToDelete)
        {
            ReadPets().Remove(petToDelete);
            return petToDelete;
        }

        public Pet EditPet(int id, Pet editedPet)
        {
            Pet petToEdit = FakeDB._pets.Find(x => x.ID == id);
            petToEdit.Name = editedPet.Name;
            petToEdit.Type = editedPet.Type;
            petToEdit.BirthDate = editedPet.BirthDate;
            petToEdit.SoldDate = editedPet.SoldDate;
            petToEdit.Color = editedPet.Color;
            petToEdit.PreviousOwner = editedPet.PreviousOwner;
            petToEdit.Price = editedPet.Price;
            return petToEdit;
        }

        public List<Pet> SearchByType(PetType type)
        {
          return FakeDB._pets.FindAll(x => x.Type == type);
        }

        public List<Pet> SortPetsByPrice()
        {
            return FakeDB._pets.OrderBy(o => o.Price).ToList();
        }

        public List<Pet> SearchByTypeAndSortByPrice(PetType type)
        {
            return SearchByType(type).OrderBy(o => o.Price).ToList();
        }
    }
}
