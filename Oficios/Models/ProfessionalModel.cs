using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Oficios.Models
{
    public class ProfessionalModel : UserModel
    {
        [Required(ErrorMessage = "A Description of yourself is required")]
        public string Description { get; set; }
        public List<JobModel> JobsMade { get; set; }
    }
}
