using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Oficios.Models
{
    public class SkillCategoryModel
    {
        [BindNever]
        public int SkillCategoryId { get; set; }

        [Required(ErrorMessage = "A SkillCategory Name is required")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "A SkillCategory Description is required")]
        [StringLength(200)]
        public string Description { get; set; }
    }
}
