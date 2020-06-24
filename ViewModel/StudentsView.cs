using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalGPTWBackendProject.ViewModel
{
    public class StudentsView
    {
        public int StudentsId{get;set;}
        public int UsersId { get; set; }
        public string Name { get; set; }

        public string Grade { get; set; }
        public string Gender { get; set; }

        public string BirthDate { get; set; }
    }
}
