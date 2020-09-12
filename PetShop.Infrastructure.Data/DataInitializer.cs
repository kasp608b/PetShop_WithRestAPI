using PetShop.Core.DomainService;
using PetShop.Core.Entities;
using PetShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entities.Entities;
using PetShop.Core.Entities.Entities.Business;
using PetType = PetShop.Core.Entities.Entities.Business.PetType;

namespace PetShop.Infrastructure.Data
{
    public class DataInitializer
    {
       
        private IPetRepository _petRepository;
        private IOwnerRepository _ownerRepository;
        private IPetTypeRepository _petTypeRepository;
        public DataInitializer(IPetRepository petRepository, IOwnerRepository ownerRepository, IPetTypeRepository petTypeRepository)
        {
            _petRepository = petRepository;
            _ownerRepository = ownerRepository;
            _petTypeRepository = petTypeRepository;
        }

        public void InitData()
        {
            List<Pet> pets;
            List<Owner> owners;
            List<PetType> petTypes;

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

            petTypes = new List<PetType> {
                new PetType
                {
                    Name = "Cat",
                },
                new PetType
                {
                    Name = "Dog",
                },
                new PetType
                {
                    Name = "Bird",
                }
            };

            foreach (PetType petType in petTypes)
            {
                _petTypeRepository.AddPetType(petType);
            }
        }
    }
}
