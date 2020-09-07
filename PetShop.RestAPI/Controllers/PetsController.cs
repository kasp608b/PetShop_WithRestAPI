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
            catch (KeyNotFoundException e)
            {
                return NotFound("Could not find requested pet\n" + e);
            }
        }

        // GET: api/<PetsController>/1
        [HttpGet("{id}")]
        public ActionResult<List<Pet>> GetPets(int id)
        {
            try
            {
                return _petService.SearchById(id);
            }
            catch (InvalidDataException e)
            {
                return BadRequest("Something went wrong with your request\n" + e);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound("Could not find requested pet\n" + e);
            }
        }

        // POST api/<PetsController>
        [HttpPost]
        public ActionResult<Pet> AddPet([FromBody] Pet pet)
        {
            try
            {
                return _petService.AddPet(pet);
            }
            catch (InvalidDataException e)
            {
                return BadRequest("Something went wrong with your request\n" + e);
            }
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public ActionResult<Pet> EditPet(int id, [FromBody] Pet pet)
        {
            try
            {
                return _petService.EditPet(id, pet);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound("Could not find requested pet\n" + e);
            }
            
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            try
            {
                return _petService.DeletePet(id);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound("Could not find requested pet\n" + e);
            }
        }
    }
}
