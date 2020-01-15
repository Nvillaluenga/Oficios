using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Oficios.Models
{
    public class SkillModel
    {
        [BindNever]
        public int SkillId { get; set; }
        [Required(ErrorMessage = "A Skill Description is required")]
        [StringLength(200)]
        public string Description { get; set; }
        [Required(ErrorMessage = "A Skill category is required")]
        public SkillCategoryModel SkillCategory { get; set; }
    }
}
