using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using PetShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PetShop.Core.Entities.Entities;

namespace PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        public List<Pet> GetAllPets()
        {
            return FakeDB._pets;
        }

        public List<Pet> GetAllPetsFiltered(Filter filter)
        {
            DateTime searchDate;
            IEnumerable<Pet> filtering = GetAllPets();

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                switch (filter.SearchField)
                {
                    case "Name":
                        filtering = filtering.Where(p => p.Name.Contains(filter.SearchText));
                        break;

                    case "Type":
                        filtering = filtering.Where(p => p.Type.Contains(filter.SearchText));
                        break;

                    case "BirthDate":
                        
                        if (DateTime.TryParse(filter.SearchText, out searchDate))
                        {
                            filtering = filtering.Where(p => p.BirthDate.Date.Equals(searchDate.Date));
                        }
                        else
                        {
                            throw new InvalidDataException("Wrong input, has to be a valid birthdate in format day/month/year");
                        }
                        
                        break;

                    case "SoldDate":
                        
                        if (DateTime.TryParse(filter.SearchText, out searchDate))
                        {
                            filtering = filtering.Where(p => p.SoldDate.Date.Equals(searchDate.Date));
                        }
                        else
                        {
                            throw new InvalidDataException("Wrong input, has to be a valid birthdate in format day/month/year");
                        }
                        break;

                    case "Color":
                        break;

                    case "PreviousOwner":
                        break;

                    case "Price":
                        break;
                    default:
                        throw new InvalidDataException("Wrong Searchfield input, searchfield has to match a coresponding pet property");

                }
            }

            return filtering.ToList();
        }

        public Pet AddPet(Pet petToAdd)
        {
            return FakeDB.AddPet(petToAdd);
        }

        public Pet DeletePet(Pet petToDelete)
        {
            GetAllPets().Remove(petToDelete);
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


        public List<Pet> SearchById(int id)
        {
            return FakeDB._pets.FindAll(x => x.ID == id);
        }
    }
}
