using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using PetShop.Core.Entities.Entities;

namespace PetShop.Infrastructure.Data
{
    public class OwnerRepository : IOwnerRepository
    {
        public List<Owner> GetAllOwners()
        {
            return FakeDB._owners;
        }

        public FilteredList<Owner> GetAllOwnersFiltered(Filter filter)
        {
            DateTime searchDate;
            Double searchDouble;
            var filteredList = new FilteredList<Owner>();

            filteredList.TotalCount = GetAllOwners().Count;
            filteredList.FilterUsed = filter;

            IEnumerable<Owner> filtering = GetAllOwners();

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                switch (filter.SearchField)
                {
                    case "Name":
                        filtering = filtering.Where(p => p.Name.Contains(filter.SearchText));
                        break;

                    case "Email":
                        filtering = filtering.Where(p => p.Email.Contains(filter.SearchText));
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

                    default:
                        throw new InvalidDataException("Wrong Search-field input, search-field has to match a corresponding pet property");

                }
            }

            if (!string.IsNullOrEmpty(filter.OrderDirection) && !string.IsNullOrEmpty(filter.OrderProperty))
            {
                var prop = typeof(Owner).GetProperty(filter.OrderProperty);
                if (prop == null)
                {
                    throw new InvalidDataException("Wrong OrderProperty input, OrderProperty has to match to corresponding owner property");
                }

                filtering = "ASC".Equals(filter.OrderDirection)
                    ? filtering.OrderBy(p => prop.GetValue(p, null))
                    : filtering.OrderByDescending(p => prop.GetValue(p, null));
            }

            filteredList.List = filtering.ToList();
            return filteredList;
        }

        public Owner AddOwner(Owner ownerToAdd)
        {
            return FakeDB.AddOwner(ownerToAdd);
        }

        public Owner DeleteOwner(Owner ownerToDelete)
        {
            GetAllOwners().Remove(ownerToDelete);
            return ownerToDelete;
        }

        public Owner EditOwner(int id, Owner editedOwner)
        {
            Owner ownerToEdit = FakeDB._owners.Find(x => x.ID == id);
            ownerToEdit.Name = editedOwner.Name;
            ownerToEdit.Email = editedOwner.Email;
            ownerToEdit.BirthDate = editedOwner.BirthDate;
            return ownerToEdit;
        }

        public List<Owner> SearchById(int id)
        {
            return FakeDB._owners.FindAll(x => x.ID == id);
        }
    }
}
