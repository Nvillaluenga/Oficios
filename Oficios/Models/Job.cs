using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Oficios.Models
{
    public class Job
    {
        [BindNever]
        public int JobId { get; set; }

        [StringLength(500)]
        public string Opinion { get; set; }
        
        [Range(0, 10, ErrorMessage = "Score can only be in the range of 0 to 10")]
        public int Score { get; set; }

        [Required(ErrorMessage = "A Job Skill is required")]
        public Skill Skill { get; set; }

        [Required(ErrorMessage = "The Worker who made this Job is required")]
        public Worker Worker { get; set; }

        [Required(ErrorMessage = "The User who received this Job is required")]
        public User User { get; set; }
        [BindNever]
        public DateTime JobPlaced { get; set; }
    }
}
