using Oficios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficios.Data
{
    public class MockJobRepository : IJobRepository
    {

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Job> GetJobAsync(int jobId)
        {
            return jobId == 1 ? Task.Factory.StartNew<Job>(() =>
                  new Job { JobId = 1, Score = 8, Skill = new Skill { Name = "Pintar" }, Opinion = "Que pingo te importa cajeta", Worker = new Worker { }, User = new User { } })
                : null;
        }

        public Task<IEnumerable<Job>> GetJobsAsync(IEnumerable<Skill> skills = null, IEnumerable<SkillCategory> skillsCategories = null)
        {
            return Task.Factory.StartNew <IEnumerable<Job>> (() => 
            {
                return new List<Job>
                {
                    new Job { JobId=1, Score = 8, Skill = new Skill {Name = "Pintar"}, Opinion = "Que pingo te importa cajeta", Worker = new Worker { }, User = new User { } }
                };
            });
        }

        public Task<Job> Add(Job job)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Job job)
        {
            throw new NotImplementedException();
        }
    }
}
