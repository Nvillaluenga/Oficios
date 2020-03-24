using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oficios.Models;

namespace Oficios.Data
{
    public interface IJobRepository
    {
        Task<Job> Add(Job job);
        Task<bool> Delete (Job job);
        Task<bool> SaveChangesAsync ();
        Task<IEnumerable<Job>> GetJobsAsync(IEnumerable<Skill> skills = null, IEnumerable<SkillCategory> skillsCategories = null);
        Task<Job> GetJobAsync(int jobId);

    }
}
