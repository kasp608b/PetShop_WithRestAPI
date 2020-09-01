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
        public static List<Pet> _pets;

        public static void InitData()
        {
            _pets = new List<Pet> {
                new Pet
                {
                    ID = _id++,
                    Name = "Jerry",
                    Type = PetType.Cat,
                    BirthDate = DateTime.Now.AddYears(-12),
                    Color = "Blue",
                    PreviousOwner = "Arnold Perkins",
                    Price = 50,
                    SoldDate = DateTime.Now.AddYears(-2),

                },
                new Pet
                {
                    ID = _id++,
                    Name = "Tom",
                    Type = PetType.Dog,
                    BirthDate = DateTime.Now.AddYears(-22),
                    Color = "Red",
                    PreviousOwner = "Cory Zemecki",
                    Price = 10,
                    SoldDate = DateTime.Now.AddYears(-5),
                },
                new Pet
                {
                    ID = _id++,
                    Name = "Cinc",
                    Type = PetType.Fish,
                    BirthDate = DateTime.Now.AddYears(-1),
                    Color = "Purple",
                    PreviousOwner = "Harold Harold",
                    Price = 100,
                    SoldDate = DateTime.Now.AddYears(-4),
                }
            };
        }

        public static Pet AddPet(Pet pet)
        {
            pet.ID = _id++;
            _pets.Add(pet);
            return pet;
        }


    }

}
