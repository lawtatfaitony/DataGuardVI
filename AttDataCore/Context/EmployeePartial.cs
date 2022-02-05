 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using AttDataSupport.Context;

namespace AttendanceBussiness.DbFirst
{
    public partial class Employee
    {
        public virtual string FullName => string.Format("{0} {1} {2}", CnName, LastName, FirstName).Trim();

        public virtual bool IsArchive
        {
            get
            {
                if(LeaveDate > EnrollmentDate)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public virtual UserIconOfEmployee UserIconOfEmployee => new UserIconOfEmployee(EmployeeId);
    }
}