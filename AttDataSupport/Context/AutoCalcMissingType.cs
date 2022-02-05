using System;
using System.Collections.Generic;
using System.Text;

namespace AttDataSupport.Context
{ 
    public enum AutoCalcMissingType
    { 
        NO_CALC = -1,
         
        NO_MISSING = 0,
         
        AUTO_MISSING_WORKON = 1,
         
        AUTO_MISSING_WORKOFF = 2,
         
        MANUAL_MISSING_WORKON = 4,
         
        MANUAL_MISSING_WORKOFF = 5,
         
        AUTO_MISSING_LUNCH_START = 6,
         
        AUTO_MISSING_LUNCH_END = 7,
         
        MANUAL_MISSING_LUNCH_START = 8,
         
        MANUAL_MISSING_LUNCH_END = 9,
         
        AUTO_MISSING_OVERTIME_START = 10,
         
        AUTO_MISSING_OVERTIME_END = 11,
         
        MANUAL_MISSING_OVERTIME_START = 12,
         
        MANUAL_MISSING_OVERTIME_END = 13
    }
}
