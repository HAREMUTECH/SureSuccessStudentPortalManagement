using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SureSuccessStudentPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SureSuccessStudentPortal.Web.Controllers
{
    public class StudentRegistrationController : Controller
    {
        private readonly ILogger<StudentRegistrationController> _logger;

        public StudentRegistrationController(ILogger<StudentRegistrationController> logger)
        {
            _logger = logger;
        }


        // GET: Student Registration List
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                List<StudentRegistrationFormDto> EmpInfo = new List<StudentRegistrationFormDto>();
                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync(Constant.List);
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        EmpInfo = JsonConvert.DeserializeObject<List<StudentRegistrationFormDto>>(EmpResponse);
                    }

                    return View(EmpInfo);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Attempting to Fecthing List of Record From the database", ex.Message);
                return View("Error");
            }


        }


        // GET: Student Registration Details
        [HttpGet]
        public async Task<ActionResult> GetDetails(Guid Id)
        {
            try
            {
                var studentInfo = new StudentRegistrationFormDto();
                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync(Constant.GetById + "/" + Id);
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var response = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api
                        studentInfo = JsonConvert.DeserializeObject<StudentRegistrationFormDto>(response);
                    }

                    return View(studentInfo);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Attempting to Fecthing List of Record From the database", ex.Message);
                return View("Error");
            }

        }


        public ActionResult Post()
        {
            return View();
        }

        // POST: Create Student Registration
        [HttpPost]
        public async Task<ActionResult> Post(StudentRegistrationFormDto studentRegistrationFormDto)
        {
            try
            {
                Guid Id = Guid.Empty;
                var studentInfo = new StudentRegistrationFormDto()
                {
                    Country = studentRegistrationFormDto.Country,
                    FirstName = studentRegistrationFormDto.FirstName,
                    LastName = studentRegistrationFormDto.LastName,
                    State = studentRegistrationFormDto.State,
                    PhoneNo = studentRegistrationFormDto.PhoneNo,
                    Email = studentRegistrationFormDto.Email
                };

                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.PostAsJsonAsync(Constant.Create, studentInfo);
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var response = Res.Content.ReadAsStringAsync().Result;
                        Id = JsonConvert.DeserializeObject<Guid>(response);
                    }

                    return RedirectToAction("GetDetails", new { id = Id });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured while saving to database", ex.Message);
                return View("Error");
            }

        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                var studentInfo = new UpdateStudentRegistrationFormDto();
                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync(Constant.GetById + "/" + id);
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var response = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api
                        studentInfo = JsonConvert.DeserializeObject<UpdateStudentRegistrationFormDto>(response);
                    }

                    return View(studentInfo);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Attempting to Fecthing Record From the database", ex.Message);
                return View("Error");
            }


        }


        // GET: Update Student Registration
        [HttpPut]
        public async Task<ActionResult> Edit(Guid id, [FromForm] UpdateStudentRegistrationFormDto updateStudentRegistrationFormDto)
        {
            try
            {
                Guid Id = Guid.Empty;
                var studentInfo = new StudentRegistrationFormDto()
                {
                    Country = updateStudentRegistrationFormDto.Country,
                    FirstName = updateStudentRegistrationFormDto.FirstName,
                    LastName = updateStudentRegistrationFormDto.LastName,
                    State = updateStudentRegistrationFormDto.State,
                    PhoneNo = updateStudentRegistrationFormDto.PhoneNo,
                    Email = updateStudentRegistrationFormDto.Email
                };

                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.PostAsJsonAsync(Constant.Update + "/" + id, studentInfo);
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var response = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api
                        Id = JsonConvert.DeserializeObject<Guid>(response);
                    }

                    return RedirectToAction("GetDetails", new { id = Id });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Attempting to Update Student registion {updateStudentRegistrationFormDto.FirstName}", ex.Message);
                return View("Error");
            }


        }


        // GET: Create Student Registration
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //Passing service base url
                    //client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.DeleteAsync(Constant.Delete + "/" + id);
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var response = Res.Content.ReadAsStringAsync().Result;
                    }
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Attempting to Delete Record From the database", ex.Message);
                return View("Error");
            }


        }
    }
}
