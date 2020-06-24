using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FinalGPTWBackendProject.Models
{
    public partial class Users
    {

        public Users()
        {
            Students = new HashSet<Students>();
            Teachers = new HashSet<Teachers>();
            Attendance = new HashSet<Attendance>();
        }


        [Required]
        public int UsersId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Password { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Role { get; set; }




        public ICollection<Students> Students { get; set; }
        public ICollection<Teachers> Teachers { get; set; }
        public ICollection<Attendance> Attendance { get; set; }
    }
}
