using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobBoard.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private JBDataContext DB;
        public JobController(JBDataContext _DB)
        {
            this.DB = _DB;
        }

        [HttpGet]
        public IEnumerable<Job> Get()
        {
            try
            {
                var JobList = DB.Jobs.ToList<Job>();
                return JobList;
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet("{id}")]
        public Job Get(int id)
        {
            try
            {
                var Job = DB.Jobs.FirstOrDefault(x => x.Id == id);
                return Job;
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        public bool Post(Job job)
        {
            try
            {
                DB.Jobs.Add(job);
                return DB.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public bool Put(Job job)
        {
            try
            {
                var JobToUpdate = DB.Jobs.FirstOrDefault(x => x.Id == job.Id);
                JobToUpdate.Description = job.Description;
                JobToUpdate.JobName = job.JobName;
                JobToUpdate.CreatedAt = job.CreatedAt;
                JobToUpdate.ExpiresAt = job.ExpiresAt;

                return DB.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                var JobDelete = DB.Jobs.FirstOrDefault(x => x.Id == id);
                DB.Remove(JobDelete);
                return DB.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}