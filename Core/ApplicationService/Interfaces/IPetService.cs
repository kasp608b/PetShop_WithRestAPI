﻿using PetShop.Core.Entities;
using PetShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        public List<Pet> GetPets();

        public Pet AddPet(Pet pet);

        public Pet DeletePet(int id);

        public Pet EditPet(int idOfPetToEdit, Pet editedPet);

        public List<Pet> SearchByType(PetType type);

        public List<Pet> SortPetsByPrice();
    }
}
