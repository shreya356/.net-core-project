using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalGPTWBackendProject.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int UsersId { get; set; }
        public string Status { get; set; }

        public string Remark { get; set; }

        [DataType(DataType.Date)]
        public DateTime AttendanceDate { get; set; }

        


        public Users Users { get; set; }
        public object Start { get; internal set; }
    }
}
