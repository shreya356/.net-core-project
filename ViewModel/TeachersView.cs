using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalGPTWBackendProject.ViewModel
{
    public class TeachersView
    {
        public int TeachersId { get; set; }

        public int UsersId { get; set; }
        public string Name { get; set; }

        public string Subject { get; set; }

        public string Gender { get; set; }

        public DateTime BirtDate { get; set; }


    }
}
