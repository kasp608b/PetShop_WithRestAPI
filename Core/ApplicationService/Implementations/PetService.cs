using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using PetShop.Core.Entities.Entities;
using PetShop.Core.Entities.Enums;
using PetShop.Core.HelperClasses.Interfaces;
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
        private IParser _parser;

        public PetService(IPetRepository petRepository, IParser parser)
        {
            _petRepository = petRepository;
            _parser = parser;
        }

        public Pet AddPet(Pet pet)
        {
            if(pet.Equals(null))
            {
                throw new InvalidDataException("Pet cannot be null");
            }

            if(pet.Name.Length < 1)
            {
                throw new InvalidDataException("Pet name has to be longer than one");
            }
            return _petRepository.AddPet(pet);
        }

        public Pet DeletePet(int id)
        {
           Pet petToDelete;
           if(!_petRepository.ReadPets().Exists(x => x.ID == id))
           {
                throw new KeyNotFoundException("A pet with this ID does not exist");
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
                throw new KeyNotFoundException("A pet with this ID does not exist");
            }
            else
            {
                return _petRepository.EditPet(idOfPetToEdit, editedPet);
            }
            
        }

        public List<Pet> GetPets(Filter filter)
        {
            if (filter.IsSort == false && filter.SearchType == PetType.DefaultPetType)
            {
                return _petRepository.ReadPets();
            }
            else if(filter.IsSort == true && !(filter.SearchType == PetType.DefaultPetType))
            {
                return SearchByTypeAndSortByPrice(filter.SearchType);
            }
            else if(filter.IsSort == false && !(filter.SearchType == PetType.DefaultPetType))
            {
                return SearchByType(filter.SearchType);
            }
            else if(filter.IsSort == true && filter.SearchType == PetType.DefaultPetType)
            {
                return SortPetsByPrice();
            }
            else 
            {
                throw new InvalidDataException("This shouldn't be happening, something went terribly wrong.");
            }

        }


        public List<Pet> SearchById(int id)
        {
            if (!_petRepository.ReadPets().Exists(x => x.ID == id))
            {
                throw new KeyNotFoundException("No pets with this id exist");
            }
            else
            {
                return _petRepository.SearchById(id);
            }
        }

        public List<Pet> SearchByType(PetType type)
        {
            List<Pet> petsFound = new List<Pet>();
            if(!(type == PetType.Cat || type == PetType.Dog || type == PetType.Fish || type == PetType.Goat || type == PetType.Parrot || type == PetType.Tiger))
            {
                throw new InvalidDataException("Invalid pet type");
            }
            else
            {
                if (!_petRepository.ReadPets().Exists(x => x.Type == type))
                {
                    throw new KeyNotFoundException("No pets of this type exist");
                }
                else
                {
                    petsFound = _petRepository.SearchByType(type);
                    return petsFound;
                }
            }
            
        }

        public List<Pet> SearchByTypeAndSortByPrice(PetType type)
        {
            List<Pet> petsFound = new List<Pet>();
            if (!(type == PetType.Cat || type == PetType.Dog || type == PetType.Fish || type == PetType.Goat || type == PetType.Parrot || type == PetType.Tiger))
            {
                throw new InvalidDataException("Invalid pet type");
            }
            else
            {
                if (!_petRepository.ReadPets().Exists(x => x.Type == type))
                {
                    throw new KeyNotFoundException("No pets of this type exist");
                }
                else
                {
                    return _petRepository.SearchByTypeAndSortByPrice(type);
                }
            }
            
        }

        public List<Pet> SortPetsByPrice()
        {
            return _petRepository.SortPetsByPrice();
        }
    }
}
