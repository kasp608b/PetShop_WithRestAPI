using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using PetShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entities.Entities;

namespace PetShop.Infrastructure.Data
{
    public class DataInitializer
    {
       
        private IPetRepository _petRepository;
        private IOwnerRepository _ownerRepository;
        public DataInitializer(IPetRepository petRepository, IOwnerRepository ownerRepository)
        {
            _petRepository = petRepository;
            _ownerRepository = ownerRepository;
        }

        public void InitData()
        {
            List<Pet> pets;
            List<Owner> owners;

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

            owners = new List<Owner> {
                new Owner
                {
                    Name = "Harold",
                    BirthDate = DateTime.Now.AddYears(-40),
                    Email = "HaroldKork@gmail.uk" 

                },
                new Owner
                {
                    Name = "Carry",
                    BirthDate = DateTime.Now.AddYears(-30),
                    Email = "KarryOckthorp@gmail.uk"
                },
                new Owner
                {
                    Name = "Tom",
                    BirthDate = DateTime.Now.AddYears(-25),
                    Email = "TomYork@gmail.uk"
                }
            };

            foreach (Owner owner in owners)
            {
                _ownerRepository.AddOwner(owner);
            }
        }
    }
}
