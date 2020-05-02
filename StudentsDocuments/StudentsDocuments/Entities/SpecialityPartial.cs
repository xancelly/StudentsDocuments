using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDocuments.Entities
{
    public partial class Group
    {
        public string FullSpeciality
        {
            get
            {
                return Speciality.Code + " " + Speciality.Name;
            }
        }
    }
}
