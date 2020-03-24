using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Oficios.Models
{
    public class Skill
    {
        [BindNever]
        public int SkillId { get; set; }
        //[Required(ErrorMessage = "A Skill Name is required")]
        [StringLength(50)]
        public string Name { get; set; }
        //[Required(ErrorMessage = "A Skill Description is required")]
        [StringLength(200)]
        public string Description { get; set; }
        //[Required(ErrorMessage = "A Skill category is required")]
        public SkillCategory SkillCategory { get; set; }

        public bool Equals(Skill skill)
        {
            return this.SkillId == skill.SkillId;
        }
    }
}
