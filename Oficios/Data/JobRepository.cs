using Oficios.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficios.Data
{
    public class JobRepository : IJobRepository
    {
        private readonly OficioDbContext _oficioDbContext;

        public JobRepository(OficioDbContext oficioDbContext)
        {
            this._oficioDbContext = oficioDbContext;
        }
         
        public async Task<Job> Add(Job job)
        {
            job.JobPlaced = DateTime.Now;
            _oficioDbContext.Jobs.Add(job);
            if (await SaveChangesAsync()) return job;
            else return null;
        }

        public async Task<bool> Delete(Job job)
        {
            _oficioDbContext.Jobs.Remove(job);
            return await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _oficioDbContext.SaveChangesAsync()) > 0;
        }

        public async Task<Job> GetJobAsync(int jobId)
        {
            return await _oficioDbContext.Jobs
                .Include((jobs) => jobs.Skill)
                .Where(job => job.JobId == jobId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Job>> GetJobsAsync(IEnumerable<Skill> skills = null, IEnumerable<SkillCategory> skillsCategories = null)
        {
            return await _oficioDbContext.Jobs
                .Include((jobs) => jobs.Skill).ToArrayAsync();
        }
    }
}
