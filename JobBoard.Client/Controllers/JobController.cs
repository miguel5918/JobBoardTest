using JobBoard.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace JobBoard.Client.Controllers
{
    public class JobController : Controller
    {
        // GET: Job
        public ActionResult Index()
        {
            try
            {
                //Invoke REST APi for Get
                HttpClient clientHttp = new HttpClient();
                clientHttp.BaseAddress = new Uri("https://localhost:44331/");


                var request = clientHttp.GetAsync("api/Job").Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var JobList = JsonConvert.DeserializeObject<List<Job>>(resultString);
                    return View(JobList);
                }
                return View(new List<Job>());
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Job job)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Invoke REST APi for Post
                    HttpClient clientHttp = new HttpClient();
                    clientHttp.BaseAddress = new Uri("https://localhost:44387/");


                    var request = clientHttp.PostAsync("api/Job", job, new JsonMediaTypeFormatter()).Result;

                    if (request.IsSuccessStatusCode)
                    {
                        var resultString = request.Content.ReadAsStringAsync().Result;
                        var Answer = JsonConvert.DeserializeObject<bool>(resultString);
                        if (Answer)
                        {
                            return RedirectToAction("Index");
                        }
                        return View(job);
                    }
                }

                return View(job);
            }
            catch (Exception)
            {

                throw;
            }
        }
        // UPDATE JOB
        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                //Invoke REST APi for Post
                HttpClient clientHttp = new HttpClient();
                clientHttp.BaseAddress = new Uri("https://localhost:44387/");


                var request = clientHttp.GetAsync("api/Job/" + id).Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var JobInfo = JsonConvert.DeserializeObject<Job>(resultString);

                    return View(JobInfo);
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Update(Job job)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Invoke REST APi for Post
                    HttpClient clientHttp = new HttpClient();
                    clientHttp.BaseAddress = new Uri("https://localhost:44387/");


                    var request = clientHttp.PutAsync("api/Job", job, new JsonMediaTypeFormatter()).Result;

                    if (request.IsSuccessStatusCode)
                    {
                        var resultString = request.Content.ReadAsStringAsync().Result;
                        var Answer = JsonConvert.DeserializeObject<bool>(resultString);
                        if (Answer)
                        {
                            return RedirectToAction("Index");
                        }
                        return View(job);
                    }
                }

                return View(job);
            }
            catch (Exception)
            {

                throw;
            }
        }


        //DELETE 
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                //Invoke REST APi for Post
                HttpClient clientHttp = new HttpClient();
                clientHttp.BaseAddress = new Uri("https://localhost:44387/");


                var request = clientHttp.DeleteAsync("api/Job/" + id).Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var Answer = JsonConvert.DeserializeObject<bool>(resultString);
                    if (Answer)
                    {
                        return RedirectToAction("Index");
                    }

                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // JOB DETAIL
        [HttpGet]
        public ActionResult Detail(int id)
        {
            try
            {
                //Invoke REST APi for Post
                HttpClient clientHttp = new HttpClient();
                clientHttp.BaseAddress = new Uri("https://localhost:44387/");


                var request = clientHttp.GetAsync("api/Job/" + id).Result;

                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                    var JobInfo = JsonConvert.DeserializeObject<Job>(resultString);
                    return View(JobInfo);

                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}