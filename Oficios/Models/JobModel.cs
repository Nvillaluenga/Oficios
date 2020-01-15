using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Oficios.Models
{
    public class JobModel
    {
        [BindNever]
        public int JobId { get; set; }

        [StringLength(500)]
        public string Opinion { get; set; }
        
        [Range(0, 10, ErrorMessage = "Score can only be in the range of 0 to 10")]
        public int Score { get; set; }

        [Required(ErrorMessage = "A Job Skill is required")]
        public SkillModel Skill { get; set; }

        [Required(ErrorMessage = "The Professional who made this Job is required")]
        public ProfessionalModel Professional { get; set; }

        [Required(ErrorMessage = "The User who received this Job is required")]
        public UserModel User { get; set; }
    }
}
