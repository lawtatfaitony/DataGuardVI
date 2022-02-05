using AttendanceBussiness.DbFirst;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AttendanceBussiness.ScheduleBusiness
{
    public partial class ScheduleUtilize
    {
        //function
        public static ScheduleChartResult ScheduleChartSearching(List<ScheduleEmployeeQuery> scheduleEmployeeQuery, string MainComId, string ContractorId, string SiteId, string DepartmentId, string PositionId, string JobId,
          string sortOrder, string searchString, long ScheduleDateStart, long ScheduleDateEnd)
        { 
            ScheduleChartResult scheduleChartResult1 = new ScheduleChartResult();
            
            //---------------------------------------------------------------------------------------------
            string[] ScheduleEmployeeDimensions = new string[]{"EmployeeId", "Gender", "Name", "RecordIndex" };
            string[] ScheduleShiftDimensions = new string[]{ "RecIndex", "WorkStart","WorkEnd","ShiftAbbrId","ShiftId","ShiftName", "Name", "IsApproved"};
            ArrayList arrScheduleEmployeeData =new ArrayList() ;
            ArrayList arrScheduleShiftData = new ArrayList();
            var employeeSchedules = from em in scheduleEmployeeQuery
                                    select new { em.EmployeeId };
            int RecIndex = 0;
            foreach (var item in employeeSchedules.Distinct())
            {
                var employee = scheduleEmployeeQuery.Where(c => c.EmployeeId.Contains(item.EmployeeId)).FirstOrDefault();
                ArrayList arrScheduleEmployee = new ArrayList
                {
                    employee.EmployeeId,
                    employee.Gender.ToUpper().Substring(0, 1),
                    employee.Name,
                    RecIndex
                };
                arrScheduleEmployeeData.Add(arrScheduleEmployee);
                RecIndex++;
            }
            int j = 0;
            foreach (var item in scheduleEmployeeQuery)
            {
                int getRecIndex = 0;
                foreach (ArrayList arr in arrScheduleEmployeeData)
                {
                    if (arr[0].ToString() == item.EmployeeId)
                    {
                        getRecIndex = int.Parse(arr[3].ToString());
                        break;
                    }
                }
                ArrayList arrScheduleShift = new ArrayList
                {
                    getRecIndex,
                    DateTimePubBusiness.ConvertDateTimeFixByDivisor(item.ScheduleDate, item.WorkStart, 1000),
                    DateTimePubBusiness.ConvertDateTimeFixByDivisor(item.ScheduleDate, item.WorkEnd, 1000),
                    item.ShiftAbbrId,
                    item.ShiftId,
                    item.ShiftName,
                    item.Name,
                    item.IsApproved
                };

                arrScheduleShiftData.Add(arrScheduleShift);

                j++;
            }
            ScheduleEmployeeStruct scheduleEmployeeStruct = new ScheduleEmployeeStruct { Dimensions = ScheduleEmployeeDimensions, Data = arrScheduleEmployeeData };
            scheduleChartResult1.ScheduleEmployee = scheduleEmployeeStruct;

            ScheduleShiftStruct scheduleShiftStruct   = new ScheduleShiftStruct { Dimensions = ScheduleShiftDimensions, Data = arrScheduleShiftData }; 
            scheduleChartResult1.ScheduleShift = scheduleShiftStruct;
            
            return scheduleChartResult1;
        } 
    }

    public class ScheduleExtend : Schedule
    {
        public string CnName { get; set; }
        public string EnName { get; set; }

        public string EmployeeDepartment { get; set; }
        public string EmployeeCompanyName { get; set; }

        public string ShiftName { get; set; }
        public string ShiftAppliedModeName { get; set; }
        public string ShiftDepartmentArr { get; set; }


    }

    public class ScheduleEmployeeQuery
    {
        public int RecIndex { get; set; }
        public string EmployeeId { get; set; }  
        public string Gender { get; set; }
        public string Name { get; set; }
        public DateTime ScheduleDate { get; set; }
        public TimeSpan WorkStart { get; set; }
        public TimeSpan WorkEnd { get; set; }
        public string ShiftAbbrId { get; set; }
        public string ShiftId { get; set; }
        public string ShiftName { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCompleted { get; set; }
    } 

    public class ScheduleShift
    {
        public int RecIndex { get; set; }
        public long WorkStart { get; set; }
        public long WorkEnd { get; set; } 
        public string ShiftAbbrId { get; set; }  
        public string ShiftId { get; set; }
        public string ShiftName { get; set; }  
        public string Name { get; set; }   
        public bool IsApproved { get; set; }  
    }
    public class ScheduleChartResult
    {
        public ScheduleEmployeeStruct ScheduleEmployee { get; set; }
        public ScheduleShiftStruct ScheduleShift { get; set; }
    }
    public class ScheduleEmployeeStruct
    {
        public string[] Dimensions { get; set; }
        public ArrayList Data { get; set; }
    }
    public class ScheduleShiftStruct
    {
        public string[] Dimensions { get; set; }
        public ArrayList Data { get; set; }
    }

}
