using PetShop.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService.Interfaces
{
    public interface IOwnerService
    {
        public List<Owner> GetOwners();

        public Owner GetOwners(int Id);

        public Owner AddOwner(Owner owner);

        public Owner DeleteOwner(int id);

        public Owner EditOwner(int idOfOwnerToEdit, Owner ownerToEdit);
    }
}
