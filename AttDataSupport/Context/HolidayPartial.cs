using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AttendanceBussiness.DbFirst
{
    public partial class Holiday
    {
        public virtual string HolidayName => string.Format("{0} {1}", HolidayCnName, HolidayEnName);
    }
}