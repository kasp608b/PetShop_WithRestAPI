using PetShop.Core.Entities;
using PetShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entities.Entities;

namespace PetShop.Infrastructure.Data
{
    public static class FakeDB
    {
        private static int _petID = 1;
        private static int _ownerID = 1;
        public static List<Pet> _pets = new List<Pet>();
        public static List<Owner> _owners = new List<Owner>();

        public static Pet AddPet(Pet pet)
        {
            pet.ID = _petID++;
            _pets.Add(pet);
            return pet;
        }

        public static Owner AddOwner(Owner owner)
        {
            owner.ID = _ownerID++;
            _owners.Add(owner);
            return owner;
        }


    }

}
