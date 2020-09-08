using PetShop.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entities
{
    public class Pet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public string PreviousOwner { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"ID = {ID.ToString()}, Name = {Name.ToString()}, Type = {Type.ToString()}, BirthDate = {BirthDate.ToString()}, SoldDate = {SoldDate.ToString()}, Color = {Color.ToString()}, PreviousOwner = {PreviousOwner.ToString()}, Price = {Price.ToString()},\n";
        }
    }
}
