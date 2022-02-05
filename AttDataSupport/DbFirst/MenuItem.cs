using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class MenuItem
    {
        public string MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string EngMenuItemName { get; set; }
        public string ParentsMenuItemId { get; set; }
        public string MenuLink { get; set; }
        public string Target { get; set; }
        public string ForRoleName { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
    }
}
