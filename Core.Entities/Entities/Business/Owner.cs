using System;

namespace PetShop.Core.Entities.Entities.Business
{
    public class Owner
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
