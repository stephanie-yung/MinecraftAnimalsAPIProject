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
    public class AnimalCategoriesController : ControllerBase
    {
        private readonly MCAnimalsDBContext _context;

        public AnimalCategoriesController(MCAnimalsDBContext context)
        {
            _context = context;
        }

        // GET: api/AnimalCategories
        [HttpGet]
        public async Task<ActionResult<Response>> GetAnimalCategories()
        {
            var response = new Response();

            var allAnimalCategories = await _context.AnimalCategories.ToListAsync();

            if (allAnimalCategories != null)
            {
                response.statusCode = 202;
                response.statusDescription = "Success. Found All Animal Categories.";
                foreach (AnimalCategories ac in allAnimalCategories)
                {
                    response.animalcategoriesresponse.Add(ac);
                }
            }
            else
            {
                response.statusCode = 400;
                response.statusDescription = "Bad Request. Unable to retrieve AnimalCategories. Please try again or check 'AnimalCategories' Table in Database.";
                response.animalcategoriesresponse = null;
            }

            return response;
        }

        // GET: api/AnimalCategories/5
        [HttpGet("{AnimalCategoriesId}")]
        public async Task<ActionResult<Response>> GetAnimalCategories(int AnimalCategoriesId)
        {

            var response = new Response();

            var animalCategories = await _context.AnimalCategories.FindAsync(AnimalCategoriesId);

            if (animalCategories == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Not Found. Unable to retrieve Animal Category ID. Please try another Animal Category Id.";
                response.animalcategoriesresponse = null;

            }
            else
            {
                response.statusCode = 202;
                response.statusDescription = "Success. Animal Category Found.";
                response.animalcategoriesresponse.Add(animalCategories);

            }

            return response;
        }

        // PUT: api/AnimalCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{AnimalCategoriesId}")]
        public async Task<ActionResult<Response>> PutAnimalCategories(int AnimalCategoriesId, AnimalCategories animalCategories)
        {
            var response = new Response();

            var AnimalCategoriesWithId = await _context.AnimalCategories.FindAsync(AnimalCategoriesId);

            if (AnimalCategoriesWithId == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Not Found. Unable to retrieve Animal Categories ID. Please try another Animal Categories Id.";
                response.breedableanimalsresponse = null;
                return response;
            }
            else
            {
                _context.Entry(AnimalCategoriesWithId).State = EntityState.Detached;

                animalCategories.AnimalCategoriesId = AnimalCategoriesId;

                _context.Entry(animalCategories).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                    response.statusCode = 200;
                    response.statusDescription = "Success. The Animal Categories Id has been Modified.";
                    response.animalcategoriesresponse.Add(animalCategories);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalCategoriesExists(AnimalCategoriesId))
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


        // POST: api/AnimalCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostAnimalCategories(AnimalCategories animalCategories)
        {
            var response = new Response();

            if (animalCategories != null)
            {
                _context.AnimalCategories.Add(animalCategories);

                await _context.SaveChangesAsync();

                response.statusCode = 201;
                response.statusDescription = "Success. Created new breedable animal object.";
                response.animalcategoriesresponse.Add(animalCategories);

            }
            else
            {
                response.statusCode = 401;
                response.statusDescription = "Bad Request. Unable to create new breedable animal object.";
                response.animalcategoriesresponse = null;
            }

            return response;
        }


        // DELETE: api/AnimalCategories/5
        [HttpDelete("{AnimalCategoriesId}")]
        public async Task<ActionResult<Response>> DeleteAnimalCategories(int AnimalCategoriesId)
        {

            var response = new Response();

            var animalCategories = await _context.AnimalCategories.FindAsync(AnimalCategoriesId);


            response.statusCode = 404;
            response.statusDescription = "Not Found. Unable to find Animal Category Id. Please try another Animal Category Id.";
            response.animalcategoriesresponse = null;



            if (animalCategories != null)
            {

                _context.AnimalCategories.Remove(animalCategories);
                await _context.SaveChangesAsync();

                response.statusCode = 202;
                response.statusDescription = "Success. Animal Category is Deleted.";

            }

            return response;
        }

        private bool AnimalCategoriesExists(int AnimalCategoriesId)
        {
            return _context.AnimalCategories.Any(e => e.AnimalCategoriesId == AnimalCategoriesId);
        }
    }
}
