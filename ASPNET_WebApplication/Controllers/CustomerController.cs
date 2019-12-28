using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ASPNET_WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASPNET_WebApplication.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: Customer
        public async Task<ActionResult> Index()
        {

            //Call ASPNET_API
            var client = _httpClientFactory.CreateClient("API_Services");
            var customerData = await client.GetAsync("Customer");
            var data = JsonConvert.DeserializeObject<List<CustomerViewModel>>(await customerData.Content.ReadAsStringAsync());
            // ConvertData into View
            return View(data);
        }

        // GET: Customer/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var client = _httpClientFactory.CreateClient("API_Services");
            var customerData = await client.GetAsync($"Customer/{id}");
            var data = JsonConvert.DeserializeObject<CustomerViewModel>(await customerData.Content.ReadAsStringAsync());
            return View(data);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(CustomerViewModel customerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var client = _httpClientFactory.CreateClient("API_Services");
                    string postBody = JsonConvert.SerializeObject(customerViewModel);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage wcfResponse = await client.PostAsync("Customer", new StringContent(postBody, Encoding.UTF8, "application/json"));
                    //var customerData = await client.GetAsync("Customer"); 
                    //_serviceLayer.SendData("FamilyApi", new FamilyDTO() { FamilyName = newFamily.FamilyName, FamilyEmail = newFamily.FamilyEmail });

                    if (!wcfResponse.IsSuccessStatusCode)
                        throw new Exception(wcfResponse.Content.ReadAsStringAsync().Result ?? "This didn't work!!!"); 
                    return RedirectToAction("Index");
                }

                return View("Create", customerViewModel);
            }
            catch
            {
                return View("Create", customerViewModel);
            }
        }

        // GET: Customer/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("API_Services");
            var customerData = await client.GetAsync($"Customer/{id}");
            var data = JsonConvert.DeserializeObject<CustomerViewModel>(await customerData.Content.ReadAsStringAsync());
            return View(data);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CustomerViewModel customerViewModel)
        {
            try
            {
                // TODO: Add update logic here
                var client = _httpClientFactory.CreateClient("API_Services");
                var jsonString = JsonConvert.SerializeObject(customerViewModel);
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"Customer/{customerViewModel.CustomerId}", httpContent);
                if (response.IsSuccessStatusCode)
                    Console.Write("Success");
                else
                    Console.Write("Error");
                //var returndata = JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("API_Services");
            var customerData = await client.DeleteAsync($"Customer/{id}");
            //if (customerData.StatusCode = HttpStatusCode.NoContent);    
            return RedirectToAction("Index");
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}