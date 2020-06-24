using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalGPTWBackendProject.Models
{
    public partial class Teachers
    {

        [Required]
        public int TeachersId { get; set; }

        [Required]
        public int UsersId { get; set; }

        [Required]
        public string Subjects { get; set; }

        public string Gender { get; set; }


        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }



        public Users Users { get; set; }

    }
}
