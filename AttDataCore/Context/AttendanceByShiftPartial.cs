using System;
using System.Collections.Generic;
using AttDataSupport.Context; 

namespace AttendanceBussiness.DbFirst
{
    public partial class AttendanceByShift
    {
        public AttendanceByShift()
        {
            IsRegularWorkOn = false;
            IsRegularWorkOff = false;

            IsRegularLunchStart = false;
            IsRegularLunchEnd = false;

            IsRegularOverTimeStart = false;
            IsRegularOverTimeEnd = false;
        }

        public virtual bool IsAutoMissingWorkOn
        {
            get
            {
                if (IsAutoCalcMissing == true && MissingWorkOn == (int)AutoCalcMissingType.AUTO_MISSING_WORKON)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public virtual bool IsRegularManualMissingWorkOn
        {
            get
            {
                if (IsRegularWorkOn == true && MissingWorkOn == (int)AutoCalcMissingType.MANUAL_MISSING_WORKON)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public virtual bool IsAutoMissingWorkOff
        {
            get
            {
                if (IsAutoCalcMissing == true && MissingWorkOff == (int)AutoCalcMissingType.AUTO_MISSING_WORKOFF)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public virtual bool IsRegularManualMissingWorkOff
        {
            get
            {
                if (IsRegularWorkOff == true && MissingWorkOff == (int)AutoCalcMissingType.MANUAL_MISSING_WORKOFF)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public virtual bool IsAutoMissingLunchStart
        {
            get
            {
                if (IsAutoCalcMissing == true && MissingLunchStart == (int)AutoCalcMissingType.AUTO_MISSING_LUNCH_START)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public virtual bool IsRegularManualMissingLunchStart
        {
            get
            {
                if (IsRegularLunchStart == true && MissingLunchStart == (int)AutoCalcMissingType.MANUAL_MISSING_LUNCH_START)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public virtual bool IsAutoMissingLunchEnd
        {
            get
            {
                if (IsAutoCalcMissing == true && MissingLunchEnd == (int)AutoCalcMissingType.AUTO_MISSING_LUNCH_END)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public virtual bool IsRegularManualMissingLunchEnd
        {
            get
            {
                if (IsRegularLunchEnd == true && MissingLunchEnd == (int)AutoCalcMissingType.MANUAL_MISSING_LUNCH_END)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public virtual bool IsAutoMissingOverTimeStart
        {
            get
            {
                if (IsAutoCalcMissing == true && MissingOverTimeStart == (int)AutoCalcMissingType.AUTO_MISSING_OVERTIME_START)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public virtual bool IsRegularManualMissingOverTimeStart
        {
            get
            {
                if (IsRegularOverTimeStart == true && MissingOverTimeStart == (int)AutoCalcMissingType.MANUAL_MISSING_OVERTIME_START)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public virtual bool IsAutoMissingOverTimeEnd
        {
            get
            {
                if (IsAutoCalcMissing == true && MissingOverTimeEnd == (int)AutoCalcMissingType.AUTO_MISSING_OVERTIME_END)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public virtual bool IsRegularManualMissingOverTimeEnd
        {
            get
            {
                if (IsRegularOverTimeEnd == true && MissingOverTimeEnd == (int)AutoCalcMissingType.MANUAL_MISSING_OVERTIME_END)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
