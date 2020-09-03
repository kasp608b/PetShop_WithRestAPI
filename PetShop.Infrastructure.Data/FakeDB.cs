using PetShop.Core.Entities;
using PetShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public static class FakeDB
    {
        private static int _id = 1;
        public static List<Pet> _pets = new List<Pet>();

        public static Pet AddPet(Pet pet)
        {
            pet.ID = _id++;
            _pets.Add(pet);
            return pet;
        }


    }

}
