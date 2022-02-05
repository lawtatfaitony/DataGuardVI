using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AttendanceBussiness
{ 
    public partial class ShiftNameStructure
    {
        public string ShiftId { get; set; }
        public string ShiftAbbrId { get; set; }
        public string IconColor { get; set; }
        public string ShiftName { get; set; }
    }
}
