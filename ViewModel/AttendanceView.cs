using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalGPTWBackendProject.ViewModel
{
    public class AttendanceView
    {
        public int AttendanceId { get; set; }
        public int UsersId { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string Status { get; set; }


        public string Remark { get; set; }

        public DateTime Attendancedate { get; set; }
    }
}
