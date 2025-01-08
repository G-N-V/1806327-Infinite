using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class CountryController : ApiController
    {
        private static List<Country> countries = new List<Country>
        {    
            new Country { ID = 1, CountryName = "India", Capital = "New Delhi" },
            new Country { ID = 2, CountryName = "USA", Capital = "Washington D.C." },
            new Country { ID = 3, CountryName = "Malaysia", Capital = "Kuala Lampur" }
        };

        
        public IEnumerable<Country> Get()
        {
            return countries;
        }

        
        public IHttpActionResult Get(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        
        public IHttpActionResult Post([FromBody] Country country)
        {
            if (country == null)
            {
                return BadRequest("Invalid data.");
            }

            
            country.ID = countries.Max(c => c.ID) + 1;
            countries.Add(country);
            return CreatedAtRoute("DefaultApi", new { id = country.ID }, country);
        }

        
        public IHttpActionResult Put(int id, [FromBody] Country country)
        {
            if (country == null || country.ID != id)
            {
                return BadRequest("Invalid data.");
            }

            var existingCountry = countries.FirstOrDefault(c => c.ID == id);
            if (existingCountry == null)
            {
                return NotFound();
            }

            existingCountry.CountryName = country.CountryName;
            existingCountry.Capital = country.Capital;
            return Ok(existingCountry);
        }

        
        public IHttpActionResult Delete(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }

            countries.Remove(country);
            return Ok();
        }
       
    }
}