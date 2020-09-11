﻿using PetShop.Core.DomainService;
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

        public FilteredList<Pet> GetAllPetsFiltered(Filter filter)
        {
            DateTime searchDate;
            Double searchDouble;
            var filteredList = new FilteredList<Pet>();

            filteredList.TotalCount = GetAllPets().Count;
            filteredList.FilterUsed = filter;

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
                            filtering = filtering.Where(p => p.BirthDate.ToShortDateString().Contains(searchDate.ToShortDateString()));
                        }
                        else
                        {
                            throw new InvalidDataException("Wrong input, has to be a valid birthdate in format day/month/year");
                        }
                        
                        break;

                    case "SoldDate":
                        
                        if (DateTime.TryParse(filter.SearchText, out searchDate))
                        {
                            filtering = filtering.Where(p => p.SoldDate.ToShortDateString().Contains(searchDate.ToShortDateString()));
                        }
                        else
                        {
                            throw new InvalidDataException("Wrong input, has to be a valid birthdate in format day/month/year");
                        }
                        break;

                    case "Color":
                        filtering = filtering.Where(p => p.Color.Contains(filter.SearchText));
                        break;

                    case "PreviousOwner":
                        filtering = filtering.Where(p => p.PreviousOwner.Contains(filter.SearchText));
                        break;

                    case "Price":
                        if (double.TryParse(filter.SearchText, out searchDouble))
                        {
                            filtering = filtering.Where(p => p.Price.Equals(searchDouble));
                        }
                        else
                        {
                            throw new InvalidDataException("Wrong input, has to be a valid double");
                        }
                        break;
                    default:
                        throw new InvalidDataException("Wrong Search-field input, search-field has to match a corresponding pet property");

                }
            }

            if (!string.IsNullOrEmpty(filter.OrderDirection) && !string.IsNullOrEmpty(filter.OrderProperty))
            {
                var prop = typeof(Pet).GetProperty(filter.OrderProperty);
                if (prop == null)
                {
                    throw new InvalidDataException("Wrong OrderProperty input, OrderProperty has to match to corresponding pet property");
                }

                filtering = "ASC".Equals(filter.OrderDirection)
                    ? filtering.OrderBy(p => prop.GetValue(p, null))
                    : filtering.OrderByDescending(p => prop.GetValue(p, null));
            }

            filteredList.List = filtering.ToList();
            return filteredList;
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
