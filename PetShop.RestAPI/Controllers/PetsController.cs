using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entities;
using PetShop.Core.Entities.Entities;
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
        public ActionResult<List<Pet>> GetPets([FromQuery] Filter filter)
        {
            try
            {
                return _petService.GetPets(filter);
            }
            catch (InvalidDataException e)
            {
                return BadRequest("Something went wrong with your request\n" + e);
            }
        }

        // GET: api/<PetsController>
        [HttpGet]
        [Route("SortPetsByPrice")]
        public ActionResult<List<Pet>> SortPetsByPrice(bool ifSort)
        {
            return _petService.SortPetsByPrice();
        }

        // GET api/<PetsController>/5
        [HttpGet]
        [Route("SearchByType/{type}")]
        public ActionResult<List<Pet>> SearchByType( PetType type)
        {
            return _petService.SearchByType(type);
        }

        // POST api/<PetsController>
        [HttpPost]
        [Route("AddPet")]
        public Pet AddPet([FromBody] Pet pet)
        {
            return _petService.AddPet(pet);
        }

        // PUT api/<PetsController>/5
        [HttpPut]
        [Route("EditPet/{id}")]
        public ActionResult<Pet> EditPet(int id, [FromBody] Pet pet)
        {
            return _petService.EditPet(id, pet);
        }

        // DELETE api/<PetsController>/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            return _petService.DeletePet(id);
        }
    }
}
