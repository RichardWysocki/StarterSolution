using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;


        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        // GET: api/Cusotmer
        [HttpGet]
        public IActionResult Get()  
        {
            //_logEngine.LogInfo("KidApiController: /api/KidApi/Get", "Starting Method");
            var getData = _customerRepository.GetAllCustomers();
            //var response = getData
            //    .Select(c => new KidDTO() { KidId = c.KidId, Name = c.Name, Email = c.Email, FamilyId = c.FamilyId }).ToList();
            //_logEngine.LogInfo("KidApiController: /api/KidApi/Get", "Returning Method");
            return Ok(getData);
        }

        // GET: api/Cusotmer/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                //_logEngine.LogInfo($"KidApiController: /api/KidApi/Get/{id}", "Starting Method");
                var getData = _customerRepository.GetCustomerByCustomerID(id);
                //var response = new KidDTO() { KidId = getData.KidId, FamilyId = getData.FamilyId, Name = getData.Name, Email = getData.Email };
                //_logEngine.LogInfo($"KidApiController: /api/KidApi/Get/{id}", "Returning Method");
                return Ok(getData);
            }
            catch (Exception e) when (e.Message == "Error getting Customer record.")
            {
                //_logEngine.LogInfo($"KidApiController: /api/KidApi/Get/{id}", "Returning NOTFOUND");
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //_logEngine.LogError("KidApiController", $"/api/KidApi/Get/{id}", e.Message);
                return StatusCode(500, "Unknown Failure: Logged");
            }

        }

        // POST: api/Cusotmer
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            //_logEngine.LogInfo($"KidApiController: /api/KidApi/Post/{kid}", "Starting Method");
            var getData = _customerRepository.CreateCustomer(customer);
            //var response = new KidDTO { KidId = getData.KidId, Name = getData.Name, Email = getData.Email, FamilyId = getData.FamilyId };
            //_logEngine.LogInfo($"KidApiController: /api/KidApi/Post/{kid}", "Returning Method");
            return Created($"/api/Customer/{getData.CustomerId}", getData);
        }

        // PUT: api/Cusotmer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            
            //_logEngine.LogInfo($"KidApiController: /api/FamilyApi/Put/{kid}", "Starting Method");
            var update = _customerRepository.UpdateCustomer(customer);
            //var getDataUpdate = _kidDataAccess.Update(new Kid() { KidId = kid.KidId, Name = kid.Name, Email = kid.Email, FamilyId = kid.FamilyId });
            if (update)
            {
                //_logEngine.LogInfo($"KidApiController: /api/KidApi/Put/{kid}", "Returning Method");
                return Accepted($"/api/CustomerApi/{customer.CustomerId}");
            }
            //_logEngine.LogInfo($"KidApiController: /api/KidApi/Put/{kid}", "Returning NOTFOUND");
            return NotFound();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            try
            {
                //_logEngine.LogInfo($"KidApiController: /api/KidApi/Delete/{id}", "Starting Method");
                _customerRepository.DeleteCustomer(id);
                //_logEngine.LogInfo($"KidApiController: /api/KidApi/Delete/{id}", "Returning Method");
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //_logEngine.LogError("KidApiController", $"/api/KidApi/Delete/{id}", e.Message);
                //_logEngine.LogInfo($"KidApiController: /api/KidApi/Delete/{id}", "Returning NOTFOUND");
                return NotFound();
            }

        }
    }
}
