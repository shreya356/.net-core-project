using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalGPTWBackendProject.Models
{
    public partial class Students
    {
        [Required]
        public int StudentsId { get; set; }

        [Required]
        public int UsersId { get; set; }

        [Required]
        public string Grade { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public virtual Users Users { get; set; }

    }
}
