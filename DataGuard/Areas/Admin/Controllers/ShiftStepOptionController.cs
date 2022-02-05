using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttendanceBussiness.DbFirst;
using AttEnumCode;
using static AttEnumCode.ShiftBusiness;

namespace DataGuard.Areas.Admin.Controllers
{
    //[option function]
    public partial class ShiftStepController : BaseController
    {
        private void ShiftAppliedModeDropDownList(string selectVaue = "")
        {
            var ShiftAppliedModeQuery = AttEnumHelper.GetSelectList<ShiftAppliedMode>();
             
            var ShiftAppliedModeListDown = this.CreateEnumSelect(ShiftAppliedModeQuery, selectVaue);
            ViewBag.ShiftAppliedMode = ShiftAppliedModeListDown;
        }
        private void ShiftBusinessModeDropDownList(string selectVaue = "")
        {
            var ShiftBusinessModeQuery = AttEnumHelper.GetSelectList<ShiftBusinessMode>(); 
            var ShiftBusinessModeListDown = this.CreateEnumSelect(ShiftBusinessModeQuery, selectVaue);
            ViewBag.ShiftBusinessMode = ShiftBusinessModeListDown;
        }
          
        private void ShiftMissingWorkOnMissingModeDropDownList(string selectedValuee)
        {
            var calcMissingMode = AttEnumHelper.GetSelectList<CalcMissingMode>();
            EnumItem deleteItem; 
            foreach (var item in calcMissingMode)
            {
                if (item.Value == "NO_CALC")
                {
                    deleteItem = item;
                    calcMissingMode.Remove(deleteItem);
                    break;
                }
            }
            //NO_CALC
            var SelectList_WorkOnMissingMode = this.CreateEnumSelect(calcMissingMode, selectedValuee.ToString());

            ViewBag.MissingWorkOn = SelectList_WorkOnMissingMode;
        }
        private void ShiftMissingWorkOffMissingModeDropDownList(string selectedValuee)
        {
            var calcMissingMode = AttEnumHelper.GetSelectList<CalcMissingMode>();
            EnumItem deleteItem ;
            //Exect NO_CALC
            
            foreach (var item in calcMissingMode)
            {
                if (item.Value == "NO_CALC")
                {
                    deleteItem = item;
                    calcMissingMode.Remove(deleteItem);
                    break;
                }
            } 
            var SelectList_WorkOffMissingMode = this.CreateEnumSelect(calcMissingMode, selectedValuee.ToString());
            ViewBag.MissingWorkOff = SelectList_WorkOffMissingMode;
        }
        private void ShiftMissingLunchStartDropDownList(string selectedValuee)
        {
            var calcMissingMode = AttEnumHelper.GetSelectList<CalcMissingMode>();
            EnumItem deleteItem;
            //Exect NO_CALC 
            foreach (var item in calcMissingMode)
            {
                if (item.Value == "NO_CALC")
                {
                    deleteItem = item;
                    calcMissingMode.Remove(deleteItem);
                    break;
                }
            }

            var SelectList_MissingLunchStart = this.CreateEnumSelect(calcMissingMode, selectedValuee.ToString());
            ViewBag.MissingLunchStart = SelectList_MissingLunchStart;
        }
        private void ShiftMissingLunchEndDropDownList(string selectedValuee)
        {
            var calcMissingMode = AttEnumHelper.GetSelectList<CalcMissingMode>();
            EnumItem deleteItem;
            //Exect NO_CALC 
            foreach (var item in calcMissingMode)
            {
                if (item.Value == "NO_CALC")
                {
                    deleteItem = item;
                    calcMissingMode.Remove(deleteItem);
                    break;
                }
            }
            var selectListCalcMissingModes = this.CreateEnumSelect(calcMissingMode, selectedValuee.ToString()); 

            ViewBag.MissingLunchEnd = selectListCalcMissingModes;
        }
        private void ShiftMissingOverTimeStartDropDownList(string selectedValuee )
        {
            var calcMissingMode = AttEnumHelper.GetSelectList<CalcMissingMode>();
            EnumItem deleteItem;
            //Exect NO_CALC 
            foreach (var item in calcMissingMode)
            {
                if (item.Value == "NO_CALC")
                {
                    deleteItem = item;
                    calcMissingMode.Remove(deleteItem);
                    break;
                }
            }
            var selectListCalcMissingModes = this.CreateEnumSelect(calcMissingMode, selectedValuee.ToString());

            ViewBag.MissingOverTimeStart = selectListCalcMissingModes;
        }
        private void ShiftMissingOverTimeEndDropDownList(string selectedValuee)
        {
            var calcMissingMode = AttEnumHelper.GetSelectList<CalcMissingMode>();
            EnumItem deleteItem;
            //Exect NO_CALC 
            foreach (var item in calcMissingMode)
            {
                if (item.Value == "NO_CALC")
                {
                    deleteItem = item;
                    calcMissingMode.Remove(deleteItem);
                    break;
                }
            }
            var selectListCalcMissingModes = this.CreateEnumSelect(calcMissingMode, selectedValuee.ToString());

            ViewBag.MissingOverTimeEnd = selectListCalcMissingModes;
        }

        private void PopulateAssignedWeekDayType(string ShiftId)
        {
            var weekDayTypes = AttEnumHelper.GetSelectList<WeekDayType>();
            var viewModel = new List<SpecialWeekDayModal>();

            if (string.IsNullOrEmpty(ShiftId))
            {
                foreach (int myweekday in Enum.GetValues(typeof(WeekDayType)))
                {
                    string SpecialWeekDays = string.Empty;
                    string name = Enum.GetName(typeof(WeekDayType), myweekday);
                    int value = myweekday;

                    viewModel.Add(new SpecialWeekDayModal
                    {
                        ShiftId = ShiftId,
                        WeekDayTypeName = name,
                        WeekDayTypeId = value.ToString(),
                        Assigned = false
                    });
                }
                ViewBag.SpecialWeekDayList = viewModel;
            }
            else
            {
                foreach (int myweekday in Enum.GetValues(typeof(WeekDayType)))
                {
                    string SpecialWeekDays = dbContext.Shift.Find(ShiftId).SpecialWeekDays;
                    string name = Enum.GetName(typeof(WeekDayType), myweekday);
                    int value = myweekday;

                    viewModel.Add(new SpecialWeekDayModal
                    {
                        ShiftId = ShiftId,
                        WeekDayTypeName = name,
                        WeekDayTypeId = value.ToString(),
                        Assigned = SpecialWeekDays.Contains(value.ToString())
                    });
                }
                ViewBag.SpecialWeekDayList = viewModel;
            }

        }
        private void PopulateAssignedExcludeWeekDay(string ShiftId)
        {
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                var weekDayTypes = AttEnumHelper.GetSelectList<WeekDayType>();
                var viewModel = new List<SpecialWeekDayModal>();

                if (string.IsNullOrEmpty(ShiftId))
                {
                    foreach (int myweekday in Enum.GetValues(typeof(WeekDayType)))
                    {
                        string SpecialWeekDays = string.Empty;
                        string name = Enum.GetName(typeof(WeekDayType), myweekday);
                        int value = myweekday;

                        viewModel.Add(new SpecialWeekDayModal
                        {
                            ShiftId = ShiftId,
                            WeekDayTypeName = name,
                            WeekDayTypeId = value.ToString(),
                            Assigned = false
                        });
                    }
                    ViewBag.ExcludeWeekDayList = viewModel;
                }
                else
                {
                    string ExcludeWeekDay = dataBaseContext.Shift.Find(ShiftId).ExcludeWeekDay;
                    foreach (int myweekday in Enum.GetValues(typeof(WeekDayType)))
                    { 
                        string name = Enum.GetName(typeof(WeekDayType), myweekday);
                        int value = myweekday;

                        viewModel.Add(new SpecialWeekDayModal
                        {
                            ShiftId = ShiftId,
                            WeekDayTypeName = name,
                            WeekDayTypeId = value.ToString(),
                            Assigned = ExcludeWeekDay == null ? false : ExcludeWeekDay.Contains(value.ToString())
                        });
                    }
                    ViewBag.ExcludeWeekDayList = viewModel;
                }
            }
            
        }

        private void PopulateAssignedExcludeOverTime(string ShiftId)
        {
            using(DataBaseContext dataBaseContext = new DataBaseContext() )
            {
                var weekDayTypes = AttEnumHelper.GetSelectList<WeekDayType>();
                var viewModel = new List<SpecialWeekDayModal>();

                if (string.IsNullOrEmpty(ShiftId))
                {
                    foreach (int myweekday in Enum.GetValues(typeof(WeekDayType)))
                    {
                        string SpecialWeekDays = string.Empty;
                        string name = Enum.GetName(typeof(WeekDayType), myweekday);
                        int value = myweekday;

                        viewModel.Add(new SpecialWeekDayModal
                        {
                            ShiftId = ShiftId,
                            WeekDayTypeName = name,
                            WeekDayTypeId = value.ToString(),
                            Assigned = false
                        });
                    }
                    ViewBag.ExcludeOverTimeList = viewModel;
                }
                else
                {
                    string ExcludeOverTime = dataBaseContext.Shift.Find(ShiftId).ExcludeOverTime;
                    foreach (int myweekday in Enum.GetValues(typeof(WeekDayType)))
                    { 
                        string name = Enum.GetName(typeof(WeekDayType), myweekday);
                        int value = myweekday;

                        viewModel.Add(new SpecialWeekDayModal
                        {
                            ShiftId = ShiftId,
                            WeekDayTypeName = name,
                            WeekDayTypeId = value.ToString(),
                            Assigned = ExcludeOverTime == null ? false : ExcludeOverTime.Contains(value.ToString())
                        });
                    }
                    ViewBag.ExcludeOverTimeList = viewModel;
                }
            }  
        }

        public string UpdateUserWeekDayType(string[] selectedWeekDayType, string ShiftId)
        {
            if (selectedWeekDayType == null)
            {
                return string.Empty;
            }
            string WeekDays = String.Join(",", selectedWeekDayType);
            return WeekDays;
        }
    }
}