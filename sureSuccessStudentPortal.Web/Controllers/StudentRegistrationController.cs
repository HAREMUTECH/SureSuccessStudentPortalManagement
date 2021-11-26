using Microsoft.AspNetCore.Mvc;
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

        public StudentRegistrationController()
        {

        }
        // GET: Student Registration List
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<StudentRegistrationFormDto> EmpInfo = new List<StudentRegistrationFormDto>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                //client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync(Constant.List);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    EmpInfo = JsonConvert.DeserializeObject<List<StudentRegistrationFormDto>>(EmpResponse);
                }
                //returning the employee list to view
                return View(EmpInfo);
            }
        }



        // GET: Student Registration Details
        [HttpGet]
        public async Task<ActionResult> GetDetails(Guid Id)
        {
            var studentInfo = new StudentRegistrationFormDto();
            using (var client = new HttpClient())
            {
                //Passing service base url
                //client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync(Constant.GetById + "/" + Id);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    studentInfo = JsonConvert.DeserializeObject<StudentRegistrationFormDto>(EmpResponse);
                }
                //returning the employee list to view
                return View(studentInfo);
            }
        }


        public ActionResult Post()
        {
            return View();
        }

        // GET: Create Student Registration
        [HttpPost]
        public async Task<ActionResult> Post(StudentRegistrationFormDto studentRegistrationFormDto)
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
                //client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsJsonAsync(Constant.Create, studentInfo);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    Id = JsonConvert.DeserializeObject<Guid>(EmpResponse);
                }
                //returning the employee list to view
                return RedirectToAction("GetDetails", new { id = Id });
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var studentInfo = new UpdateStudentRegistrationFormDto();
            using (var client = new HttpClient())
            {
                //Passing service base url
                //client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync(Constant.GetById + "/" + id);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    studentInfo = JsonConvert.DeserializeObject<UpdateStudentRegistrationFormDto>(EmpResponse);
                }
                //returning the employee list to view
                return View(studentInfo);

            }

        }


        // GET: Create Student Registration
        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, [FromForm] UpdateStudentRegistrationFormDto updateStudentRegistrationFormDto)
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
                //client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.PostAsJsonAsync(Constant.Update + "/" + id, studentInfo);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    Id = JsonConvert.DeserializeObject<Guid>(EmpResponse);
                }
                //returning the employee list to view
                return RedirectToAction("GetDetails", new { id = Id });
            }
        }


        // GET: Create Student Registration
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {


            using (var client = new HttpClient())
            {
                //Passing service base url
                //client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.DeleteAsync(Constant.Delete + "/" + id);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    //message = JsonConvert.DeserializeObject<string>(EmpResponse);
                }
                //returning the employee list to view
                return View("Post");
            }
        }
    }
}
