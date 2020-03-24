using Microsoft.EntityFrameworkCore;
using Oficios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficios.Data
{
    public class SkillRepository : ISkillRepository
    {
        private readonly OficioDbContext _oficioDbContext;

        SkillRepository(OficioDbContext oficioDbContext)
        {
            this._oficioDbContext = oficioDbContext;
        }
        public async Task<Skill> Add(Skill skill)
        {
            _oficioDbContext.Skills.Add(skill);
            if (await SaveChangesAsync()) return skill;
            else return null;
        }

        public async Task<bool> Delete(Skill skill)
        {
            _oficioDbContext.Skills.Remove(skill);
            return await SaveChangesAsync();

        }

        public async Task<Skill> GetSkillAsync(int skillId)
        {
            return await _oficioDbContext.Skills
                .Include(skill => skill.SkillCategory)
                .Where(skill => skill.SkillId == skillId)
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Skill>> GetSkillsAsync(IEnumerable<SkillCategory> skillsCategories = null)
        {
            return await _oficioDbContext.Skills
                .Include(skill => skill.SkillCategory)
                .Where(skill => skillsCategories == null ? true : skill.SkillCategory.Equals(skillsCategories))
                .ToArrayAsync();
        }

        public async Task<IEnumerable<SkillCategory>> GetSkillCategoriesAsync()
        {
            return await _oficioDbContext.SkillCategories
                .ToArrayAsync();
        }

        public async Task<SkillCategory> GetSkillCategoryAsync(int skillCategoryId)
        {
            return await _oficioDbContext.SkillCategories
                .Where(sCategory => sCategory.SkillCategoryId == skillCategoryId)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _oficioDbContext.SaveChangesAsync()) > 0;
        }
    }
}
