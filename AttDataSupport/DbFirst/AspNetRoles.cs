using System;
using System.Collections.Generic;

namespace AttendanceBussiness.DbFirst
{
    public partial class AspNetRoles
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Discriminator { get; set; }
    }
}
