using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;
using PetShop.Core.Entities.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {

        private readonly IPetService _petService;
        public PetsController(IPetService petservice)
        {
            _petService = petservice;
        }

        // GET: api/<PetsController>
        [HttpGet]
        public ActionResult<List<Pet>> GetPets()
        {
            return _petService.GetPets();
        }

        // GET: api/<PetsController>
        [HttpGet("{sort}")]
        public ActionResult<List<Pet>> SortPetsByPrice(string sort)
        {
            return _petService.SortPetsByPrice();
        }

        // GET api/<PetsController>/5
        [HttpGet("{type}")]
        public ActionResult<List<Pet>> SearchByType( PetType type)
        {
            return _petService.SearchByType(type);
        }

        // POST api/<PetsController>
        [HttpPost]
        public Pet AddPet([FromBody] Pet pet)
        {
            return _petService.AddPet(pet);
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public Pet EditPet(int id, [FromBody] Pet pet)
        {
            return _petService.EditPet(id, pet);
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public Pet Delete(int id)
        {
            return _petService.DeletePet(id);
        }
    }
}
