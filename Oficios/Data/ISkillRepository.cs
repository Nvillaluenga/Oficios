using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oficios.Models;

namespace Oficios.Data
{
    public interface ISkillRepository
    {
        Task<Skill> Add(Skill job);
        Task<bool> Delete(Skill job);
        Task<IEnumerable<Skill>> GetSkillsAsync(IEnumerable<SkillCategory> skillsCategories = null);
        Task<Skill> GetSkillAsync(int skillId);
        Task<IEnumerable<SkillCategory>> GetSkillCategoriesAsync();
        Task<SkillCategory> GetSkillCategoryAsync(int skillCategoryId);

    }
}
