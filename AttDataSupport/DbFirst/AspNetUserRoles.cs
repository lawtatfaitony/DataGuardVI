using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class AspNetUserRoles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string Discriminator { get; set; }
        public string RoleId1 { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
