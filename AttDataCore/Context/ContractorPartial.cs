using System;
using System.Collections.Generic; 
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AttendanceBussiness.DbFirst
{
    public partial class Contractor
    { 
        public virtual string ServiceDateRange => string.Format("{0:yyyy-MM-dd}-{1:yyyy-MM-dd}",this.ServiceStartDate, this.ServiceEndDate);
    }
}