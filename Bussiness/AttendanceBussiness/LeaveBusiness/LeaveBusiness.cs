using AttendanceBussiness.LeaveBusiness;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Common; 
using System.Threading;
using System.Text;
using AttendanceBussiness.DbFirst;
using AttendanceBussiness;
using static AttendanceBussiness.ShiftBusiness;
using Common;
using Newtonsoft.Json;
namespace AttendanceBussiness.LeaveBusiness
{
    public partial class LeaveBusiness
    {
        public static List<LeaveBusinessView> GetLeaveListPane(DataBaseContext dbContext, string MainComId, int Take)
        {
            List<LeaveBusinessView> leavePaneViewList = new List<LeaveBusinessView>();
            // c.LeaveStartDate.Ticks > DateTime.Now.Ticks &&
            var leaves = dbContext.Leave.Where(c => c.LeaveStartDate.Ticks > DateTime.Now.Ticks).Take(Take).OrderByDescending(c => c.CreatedDate).Take(Take).ToList();
            foreach (var item in leaves)
            {
                ShiftBusiness.LeaveType leaveType = (ShiftBusiness.LeaveType)item.LeaveType;
                string LeaveTypeName = leaveType.GetDescription();
               
                ShiftBusiness.LeavePaidType leavePaidType = (ShiftBusiness.LeavePaidType)item.LeavePaidType;
                string LeavePaidTypeName = leavePaidType.GetDescription();
                string UserIcon = dbContext.Employee.Find(item.EmployeeId).UserIcon;
                UserIcon = string.IsNullOrEmpty(UserIcon) ? "/Content/Images/User80x.jpg" : UserIcon;
                LeaveBusinessView leavePaneView = new LeaveBusinessView
                {
                    LeaveId = item.LeaveId,
                    EmployeeId = item.EmployeeId,
                    EmployeeName = item.EmployeeName,
                    EmployeeIcon = UserIcon,
                    LeaveTypeName = LeaveTypeName,
                    LeavePaidType = item.LeavePaidType,
                    LeavePaidTypeName = LeavePaidTypeName,
                    LeaveDateTimeRange = string.Format("{0:MM-dd HH:mm} To {1:MM-dd HH:mm}", item.LeaveStartDate, item.LeaveEndDate),
                    TotalDays = item.TotalDays,
                    Reason = item.Reason,
                    IsApproved = item.IsApproved,
                    ApplovedBy = item.ApplovedBy,
                    OperatedUserName = item.OperatedUserName,
                    CreatedDate = item.CreatedDate,
                    MainComId = item.MainComId
                };
                leavePaneViewList.Add(leavePaneView);
            }

            Take = leaves.Count() > 5 ? 1 : Math.Abs(Take - leaves.Count());
            Take = Take > 6 ? 6 : Take;
            var leavesIsApproved = dbContext.Leave.Where(c => c.LeaveStartDate.Ticks > DateTime.Now.Ticks).Take(Take).OrderByDescending(c => c.CreatedDate).ToList();
             
            foreach (var item in leavesIsApproved)
            {
                LeaveType leaveType = (LeaveType)item.LeaveType;
                string LeaveTypeName = leaveType.GetDescription();

                LeavePaidType leavePaidType = (LeavePaidType)item.LeavePaidType;
                string LeavePaidTypeName = leavePaidType.GetDescription();
                string UserIcon = dbContext.Employee.Find(item.EmployeeId).UserIcon;
                UserIcon = string.IsNullOrEmpty(UserIcon) ? "/Content/Images/User.jpg" : UserIcon;
                LeaveBusinessView leavePaneView = new LeaveBusinessView
                {
                    LeaveId = item.LeaveId,
                    EmployeeId = item.EmployeeId,
                    EmployeeName = item.EmployeeName,
                    EmployeeIcon = UserIcon,
                    LeaveTypeName = LeaveTypeName,
                    LeavePaidType = item.LeavePaidType,
                    LeavePaidTypeName = LeavePaidTypeName,
                    LeaveDateTimeRange = string.Format("{0:MM-dd HH:mm} To {0:MM-dd HH:mm}", item.LeaveStartDate, item.LeaveEndDate),
                    TotalDays = item.TotalDays,
                    Reason = item.Reason,
                    IsApproved = item.IsApproved,
                    ApplovedBy = item.ApplovedBy,
                    OperatedUserName = item.OperatedUserName,
                    CreatedDate = item.CreatedDate,
                    MainComId = item.MainComId
                };
                leavePaneViewList.Add(leavePaneView);
            }

            int leaves_before_count = 1;
            if (leavePaneViewList.Count() < Take)
                leaves_before_count = leaves_before_count + Take - leavePaneViewList.Count();
               
            // before
            var leaves_before = dbContext.Leave.Where(c => c.IsApproved == false && c.ApplovedBy == "0" && c.MainComId == MainComId).Take(leaves_before_count).OrderByDescending(c => c.CreatedDate).Take(1).ToList();
            foreach (var item in leaves_before)
            {
                LeaveType leaveType = (LeaveType)item.LeaveType;
                string LeaveTypeName = leaveType.GetDescription();

                LeavePaidType leavePaidType = (LeavePaidType)item.LeavePaidType;
                string LeavePaidTypeName = leavePaidType.GetDescription();
                string UserIcon = dbContext.Employee.Find(item.EmployeeId).UserIcon;
                UserIcon = string.IsNullOrEmpty(UserIcon) ? "/Content/Images/User.jpg" : UserIcon;
                LeaveBusinessView leavePaneView = new LeaveBusinessView
                {
                    LeaveId = item.LeaveId,
                    EmployeeId = item.EmployeeId,
                    EmployeeName = item.EmployeeName,
                    EmployeeIcon = UserIcon,
                    LeaveTypeName = LeaveTypeName,
                    LeavePaidType = item.LeavePaidType,
                    LeavePaidTypeName = LeavePaidTypeName,
                    LeaveDateTimeRange = string.Format("{0:MM-dd HH:mm} To {0:MM-dd HH:mm}", item.LeaveStartDate, item.LeaveEndDate),
                    TotalDays = item.TotalDays,
                    Reason = item.Reason,
                    IsApproved = item.IsApproved,
                    ApplovedBy = item.ApplovedBy,
                    OperatedUserName = item.OperatedUserName,
                    CreatedDate = item.CreatedDate,
                    MainComId = item.MainComId
                };
                leavePaneViewList.Add(leavePaneView);
            }
            return leavePaneViewList;
        }
    }
}
