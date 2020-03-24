using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Oficios.Models
{
    public class Worker : User
    {
        [Required(ErrorMessage = "A Description of yourself is required")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Job> JobsMade { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
