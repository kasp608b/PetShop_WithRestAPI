using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Interfaces;
using PetShop.Core.Entities.Entities.Business;
using PetShop.Core.Entities.Entities.DTO;
using PetShop.Core.Entities.Entities.Filter;
using PetShop.Core.Entities.Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetTypesController : ControllerBase
    {
        private readonly IPetTypeService _petTypeService;
        private readonly IPetService _petService;
        public PetTypesController(IPetTypeService petTypeService, IPetService petService)
        {
            _petTypeService = petTypeService;
            _petService = petService;
        }


        // GET: api/<PetsController>
        [HttpGet]
        public ActionResult<FilteredList<PetType>> GetPetTypes([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_petTypeService.GetPetTypes(filter));
            }
            catch (InvalidDataException e)
            {
                return BadRequest("Something went wrong with your request\n" + e.Message);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound("Could not find requested petType\n" + e.Message);
            }
            catch (DataBaseException e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET: api/<PetsController>/1
        [HttpGet("{id}")]
        public ActionResult<PetTypeDTO> GetPetTypes(int id)
        {
            PetType petType;
            PetTypeDTO petTypeDTO;

            try
            {
                petType = _petTypeService.SearchById(id);
                petTypeDTO = new PetTypeDTO
                {
                    ID = petType.ID,
                    Name = petType.Name,
                    Pets = _petService.GetPets().FindAll(pet => pet.PetTypeID == petType.ID)
                };

                return Ok(petTypeDTO);
            }
            catch (InvalidDataException e)
            {
                return BadRequest("Something went wrong with your request\n" + e.Message);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound("Could not find requested petType\n" + e.Message);
            }
            catch (DataBaseException e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/<PetsController>
        [HttpPost]
        public ActionResult<PetType> AddPetType([FromBody] PetType petType)
        {
            try
            {
                return Ok(_petTypeService.AddPetType(petType));
            }
            catch (InvalidDataException e)
            {
                return BadRequest("Something went wrong with your request\n" + e.Message);
            }
            catch (DataBaseException e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public ActionResult<PetType> EditPetType(int id, [FromBody] PetType petType)
        {
            try
            {
                return Ok(_petTypeService.EditPetType(id, petType));
            }
            catch (InvalidDataException e)
            {
                return BadRequest("Something went wrong with your request\n" + e.Message);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound("Could not find requested petType\n" + e.Message);
            }
            catch (DataBaseException e)
            {
                return StatusCode(500, e.Message);
            }

        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public ActionResult<PetType> Delete(int id)
        {
            try
            {
                return Ok(_petTypeService.DeletePetType(id));
            }
            catch (InvalidDataException e)
            {
                return BadRequest("Something went wrong with your request\n" + e.Message);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound("Could not find requested petType\n" + e.Message);
            }
            catch (DataBaseException e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
