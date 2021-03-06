﻿using System;
using System.Collections.Generic;

namespace PetShop.Core.Entities.Entities.Business
{
    public class Owner
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"ID = {ID.ToString()}, Name = {Name.ToString()}, BirthDate = {BirthDate.ToString()}, Email = {Email.ToString()},\n";
        }
    }
}
