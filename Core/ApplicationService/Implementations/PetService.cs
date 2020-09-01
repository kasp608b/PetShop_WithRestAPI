using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using PetShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PetShop.Core.ApplicationService.Implementations
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;
        
        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet AddPet(Pet pet)
        {
          
            return _petRepository.AddPet(pet);
        }

        public Pet DeletePet(int id)
        {
           Pet petToDelete;
           if(!_petRepository.ReadPets().Exists(x => x.ID == id))
           {
                throw new InvalidDataException("A pet with this ID does not exist");
           }
           else 
           {
                petToDelete = _petRepository.ReadPets().Find(x => x.ID == id);
                return _petRepository.DeletePet(petToDelete);
           }

        }

        public Pet EditPet(int idOfPetToEdit, Pet editedPet)
        {
            if (!_petRepository.ReadPets().Exists(x => x.ID == idOfPetToEdit))
            {
                throw new InvalidDataException("A pet with this ID does not exist");
            }
            else
            {
                return _petRepository.EditPet(idOfPetToEdit, editedPet);
            }
            
        }

        public List<Pet> GetPets()
        {
            return _petRepository.ReadPets();
        }

        public List<Pet> SearchByType(PetType type)
        {
            List<Pet> petsFound = new List<Pet>();

            if(!_petRepository.ReadPets().Exists(x => x.Type == type))
            {
                throw new InvalidDataException("No pets of this type exist");
            }
            else 
            {
                petsFound = _petRepository.ReadPets().FindAll(x => x.Type == type);
                return petsFound;
            }



        }

        public List<Pet> SortPetsByPrice()
        {
           return _petRepository.ReadPets().OrderBy(o => o.Price).ToList();
        }
    }
}
