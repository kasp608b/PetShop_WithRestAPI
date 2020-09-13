using System;
using PetShop.Core.Entities.Entities.Business;

namespace PetShop.Core.Entities.Entities.DTO
{
    public class PetDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public PetType PetType { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public Owner PreviousOwner { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"ID = {ID.ToString()}, Name = {Name.ToString()}, Type = {PetType.ToString()}, BirthDate = {BirthDate.ToString()}, SoldDate = {SoldDate.ToString()}, Color = {Color.ToString()}, PreviousOwner = {PreviousOwner.ToString()}, Price = {Price.ToString()},\n";
        }
    }
}