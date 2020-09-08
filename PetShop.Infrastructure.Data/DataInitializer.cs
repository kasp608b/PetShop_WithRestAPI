using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using PetShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class DataInitializer
    {
       
        private IPetRepository _petRepository;
        public DataInitializer(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public void InitData()
        {
            List<Pet> pets;

            pets = new List<Pet> {
                new Pet
                {
                    Name = "Jerry",
                    Type = "cat",
                    BirthDate = DateTime.Now.AddYears(-12),
                    Color = "Blue",
                    PreviousOwner = "Arnold Perkins",
                    Price = 50,
                    SoldDate = DateTime.Now.AddYears(-2),

                },
                new Pet
                {
                    Name = "Tom",
                    Type = "dog",
                    BirthDate = DateTime.Now.AddYears(-22),
                    Color = "Red",
                    PreviousOwner = "Cory Zemecki",
                    Price = 10,
                    SoldDate = DateTime.Now.AddYears(-5),
                },
                new Pet
                {
                    Name = "Cinc",
                    Type = "parrot",
                    BirthDate = DateTime.Now.AddYears(-1),
                    Color = "Purple",
                    PreviousOwner = "Harold Harold",
                    Price = 100,
                    SoldDate = DateTime.Now.AddYears(-4),
                }
            };

            foreach (Pet pet in pets)
            {
                _petRepository.AddPet(pet);
            }
        }
    }
}
