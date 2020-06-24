using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalGPTWBackendProject.ViewModel
{
    public class UsersView
    {
        public int UsersId { get; set; }
        public string Name { get; set; }

        public int AttendanceId { get; set; }
        public string password { get; set; }


        public string Role { get;  set; }

        public string Status { get; set; }


        public string Remark { get; set; }

        public DateTime AttendanceDate { get; set; }

        public AttendanceView Attendance { get; set; }
        public TeachersView Teachers { get; set; }
        public StudentsView Students { get; set; }

    }
}
