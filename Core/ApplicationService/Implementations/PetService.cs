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

        public Pet EditPet(int id, string name, PetType type, DateTime birthdate, DateTime soldDate, string color, string previousOwner, double price)
        {
            if (!_petRepository.ReadPets().Exists(x => x.ID == id))
            {
                throw new InvalidDataException("A pet with this ID does not exist");
            }
            else
            {
                Pet petToEdit = new Pet
                {
                    Name = name,
                    Type = type,
                    BirthDate = birthdate,
                    SoldDate = soldDate,
                    Color = color,
                    PreviousOwner = previousOwner,
                    Price = price
                };

                return _petRepository.EditPet(id, petToEdit);
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
