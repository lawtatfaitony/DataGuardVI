using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class Position
    {
        public Position()
        {
            ParentsNodeId = "0"; //default value = 0(IsParentsNode) 
        }
        public virtual string PositionFullName => string.Format("{0} {1}", PositionTitle, EnPositionTitle).Trim();
    }
}
