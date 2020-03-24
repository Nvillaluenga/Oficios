using Microsoft.AspNetCore.Mvc;
using Oficios.Data;
using Oficios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Oficios.Controllers
{
    public class JobController
    {
        private readonly IJobRepository _jobRepository;

        public JobController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Job>> Jobs([FromQuery] int[] skills, [FromQuery] int[] categories)
        {
            var jobs = await _jobRepository.GetJobsAsync();
            return jobs;
        }
        [HttpGet]
        public async Task<Job> Job(int id)
        {
            var job = await _jobRepository.GetJobAsync(id);
            return job;
        }
    }
}
