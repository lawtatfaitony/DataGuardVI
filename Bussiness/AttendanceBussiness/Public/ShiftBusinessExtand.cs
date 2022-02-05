using AttApiViewModal;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness.Public;
using AttEnumCode;
using LanguageResource;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AttendanceBussiness
{
    public class ShiftBusinessExtand
    {
        private static AttendanceBussiness.DbFirst.DataBaseContext dbContext = new AttendanceBussiness.DbFirst.DataBaseContext();
        private static string LanguageCode = LangUtilities.LanguageCode;
        public static bool ShiftInScheduleRejectToModified(string ShiftId, ref ModalDialog modalDialog )
        {
            var schedule = dbContext.Schedule.Where(c => c.ShiftId.Contains(ShiftId) && c.ScheduleDate > DateTime.Now);
            if (schedule.Count() > 0)
            {
                modalDialog.MsgCode = "-1";
                modalDialog.Message = Lang.Shift_ShiftInScheduleRejectToModified_True;
                return true;
            }
            else
            {
                modalDialog.MsgCode = "1";
                modalDialog.Message = Lang.Shift_ShiftInScheduleRejectToModified_False;
                return false;
            } 
        }
        public static bool ShiftInScheduleRejectToModified(string ShiftId, ref ResponseModalX responseModalX)
        {
            var schedule = dbContext.Schedule.Where(c => c.ShiftId.Contains(ShiftId) && c.ScheduleDate > DateTime.Now);
            if (schedule.Count() > 0)
            {
                responseModalX.meta = new MetaModalX {ErrorCode = (int)GeneralReturnCode.SUCCESS,Success = true, Message = Lang.Shift_ShiftInScheduleRejectToModified_True }; 
                return true;
            }
            else
            {
                responseModalX.meta = new MetaModalX { ErrorCode = (int)GeneralReturnCode.SUCCESS, Success = true, Message = Lang.Shift_ShiftInScheduleRejectToModified_False }; 
                return false;
            }
        }
        public static bool ShiftIsApproved(string ShiftId, ref ModalDialog modalDialog)
        {
            bool IsApproved = dbContext.Shift.Find(ShiftId).IsApproved;
            if (IsApproved)
            {
                modalDialog.MsgCode = "1";
                modalDialog.Message = Lang.Shift_ShiftIsApproved_True;
                return true;
            }
            else
            {
                modalDialog.MsgCode = "-1";
                modalDialog.Message = Lang.Shift_ShiftIsApproved_False;
                return false;
            }
        }

    }  
}