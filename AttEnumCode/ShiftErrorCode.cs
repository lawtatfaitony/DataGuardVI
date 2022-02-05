using System;
using System.ComponentModel;
using System.Reflection;
namespace AttEnumCode
{ 
    public enum ShiftErrorCode
    {
        [EnumDisplayName("SHIFT_ERROR_NO_SHIFT_ID_OR_NULL")]
        SHIFT_ERROR_NO_SHIFT_ID_OR_NULL = 100001,
        [EnumDisplayName("Shift_AppliedStartDateIsNotLogical_Validator")]
        APPLIED_STARTDATE_NOT_LOGICAL = 100002
    }
     
}
