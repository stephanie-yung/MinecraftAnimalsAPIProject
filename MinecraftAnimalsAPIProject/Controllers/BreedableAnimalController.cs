#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCAnimalsAPI.Models;

namespace MCAnimalsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedableAnimalController : ControllerBase
    {
        private readonly MCAnimalsDBContext _context;

        public BreedableAnimalController(MCAnimalsDBContext context)
        {
            _context = context;
        }

        // GET: api/BreedableAnimal
        [HttpGet]
        public async Task<ActionResult<Response>> GetBreedableAnimal()
        {
            var response = new Response();
            var allBreedableAnimals = await _context.BreedableAnimal.ToListAsync();

            if (allBreedableAnimals != null)
            {
                response.statusCode = 202;
                response.statusDescription = "Success. Found All Breedable Animals.";
                foreach (BreedableAnimal ba in allBreedableAnimals)
                {
                    response.breedableanimalsresponse.Add(ba);
                }
            }
            else
            {
                response.statusCode = 400;
                response.statusDescription = "Bad Request. Unable to retrieve BreedableAnimal. Please try again or check 'BreedableAnimal' Table in Database.";
                response.breedableanimalsresponse = null;
            }

            return response;
        }

        // GET: api/BreedableAnimal/5
        [HttpGet("{BreedableAnimalId}")]
        public async Task<ActionResult<Response>> GetBreedableAnimal(int BreedableAnimalId)
        {
            var breedableAnimal = await _context.BreedableAnimal.FindAsync(BreedableAnimalId);
            //var breedableAnimal = await _context.BreedableAnimal.Include(ba => ba.AnimalCategories).ToListAsync();

            var response = new Response();

            if (breedableAnimal != null)
            {
                response.statusCode = 202;
                response.statusDescription = "Success. Animal ID Found.";

                response.breedableanimalsresponse.Add(breedableAnimal);
            }
            else
            {

                response.statusCode = 404;
                response.statusDescription = "Request Not Found. Unable to retrieve Animal ID. Please try a valid Animal ID.";
                response.breedableanimalsresponse = null;
            }



            return response;

        }

        // PUT: api/BreedableAnimal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{BreedableAnimalId}")]
        public async Task<ActionResult<Response>> PutBreedableAnimal(int BreedableAnimalId, BreedableAnimal breedableAnimal)
        {
            var response = new Response();

            //var breedableAnimalwithId = await _context.BreedableAnimal.FindAsync(BreedableAnimalId);

            if (breedableAnimal.BreedableAnimalId != BreedableAnimalId)
            {
                response.statusCode = 404;
                response.statusDescription = "Not Found. Unable to retrieve Animal ID. Please try another Animal Id.";
                response.breedableanimalsresponse = null;

                return response;
            }
            else
            {

                //breedableAnimal.BreedableAnimalId = BreedableAnimalId;

                _context.Entry(breedableAnimal).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                response.statusCode = 200;
                response.statusDescription = "Success. Breedable Animal has been Modified.";
                response.breedableanimalsresponse.Add(breedableAnimal);


                try
                {
                    //await _context.SaveChangesAsync();
                    response.statusCode = 200;
                    //response.statusDescription = "Success. Breedable Animal has been Modified.";
                    //response.breedableanimalsresponse.Add(breedableAnimal);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreedableAnimalExists(BreedableAnimalId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }


            return response;
        }

        // POST: api/BreedableAnimal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostBreedableAnimal(BreedableAnimal breedableAnimal)
        {
            var response = new Response();

            if (breedableAnimal != null)
            {
                _context.BreedableAnimal.Add(breedableAnimal);

                await _context.SaveChangesAsync();

                response.statusCode = 201;
                response.statusDescription = "Success. Created new breedable animal object.";
                response.breedableanimalsresponse.Add(breedableAnimal);

            }
            else
            {
                response.statusCode = 401;
                response.statusDescription = "Bad Request. Unable to create new breedable animal object.";
                response.breedableanimalsresponse = null;
            }

            return response;
        }

        // DELETE: api/BreedableAnimal/5
        [HttpDelete("{BreedableAnimalId}")]
        public async Task<ActionResult<Response>> DeleteBreedableAnimal(int BreedableAnimalId)
        {

            var response = new Response();

            var breedableAnimal = await _context.BreedableAnimal.FindAsync(BreedableAnimalId);


            response.statusCode = 404;
            response.statusDescription = "Not Found. Unable to find Animal Id. Please try another Animal Id.";
            response.breedableanimalsresponse = null;

            if (breedableAnimal != null)
            {

                _context.BreedableAnimal.Remove(breedableAnimal);
                await _context.SaveChangesAsync();

                response.statusCode = 202;
                response.statusDescription = "Success. Animal Id is Deleted.";

            }



            return response;
        }

        private bool BreedableAnimalExists(int BreedableAnimalId)
        {
            return _context.BreedableAnimal.Any(e => e.BreedableAnimalId == BreedableAnimalId);
        }
    }
}
