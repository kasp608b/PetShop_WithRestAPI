﻿using PetShop.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService.Interfaces
{
    public interface IOwnerService
    {
        public FilteredList<Owner> GetOwners(Filter filter);

        public Owner AddOwner(Owner owner);

        public Owner DeleteOwner(int id);

        public Owner EditOwner(int idOfOwnerToEdit, Owner editedOwner);

        public List<Owner> SearchById(int id);
    }
}
