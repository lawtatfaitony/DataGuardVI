using DataGuard.Utilities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using static AttendanceBussiness.ShiftBusiness;

namespace DataGuard.Areas.Admin.Controllers
{
    public partial class SysBusinessSettingController : BaseController
    {
        private void ShiftAppliedModeDropDownList(object selectedShiftAppliedMode = null)
        {
            var ShiftAppliedModeQuery = EnumHelperX.GetSelectList<ShiftAppliedMode>();
            var ShiftAppliedModeListDown = new SelectList(ShiftAppliedModeQuery, "Value", "Text", selectedShiftAppliedMode);

            ViewBag.ShiftAppliedMode = ShiftAppliedModeListDown;
        }
        private void ShiftBusinessModeDropDownList(object selectedShiftBusinessMode = null)
        {
            var ShiftBusinessModeQuery = EnumHelperX.GetSelectList<ShiftBusinessMode>();
            var ShiftBusinessModeListDown = new SelectList(ShiftBusinessModeQuery, "Value", "Text", selectedShiftBusinessMode);

            ViewBag.ShiftBusinessMode = ShiftBusinessModeListDown;
        }
        //private void ApprovedModeDropDownList(object selectedApprovedMode = null)
        //{
        //    var ApprovedModeQuery = EnumHelperX.GetSelectList<ApprovedMode>();
        //    var ApprovedModeListDown = new SelectList(ApprovedModeQuery, "Value", "Text", selectedApprovedMode);

        //    ViewBag.ApprovedMode = ApprovedModeListDown;
        //}

        private void ShiftMissingWorkOnMissingModeDropDownList(object selectedShiftWorkOnMissingMode = null)
        {
            var calcMissingMode = EnumHelperX.GetSelectList<CalcMissingMode>();
            //Exect NO_CALC
            SelectListItem deleteItem = new SelectListItem();
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
            var SelectList_WorkOnMissingMode = new SelectList(calcMissingMode, "Value", "Text", selectedShiftWorkOnMissingMode);

            ViewBag.MissingWorkOn = SelectList_WorkOnMissingMode;
        }
        private void ShiftMissingWorkOffMissingModeDropDownList(object selectedShiftWorkOffMissingMode = null)
        {
            var calcMissingMode = EnumHelperX.GetSelectList<CalcMissingMode>();
            //Exect NO_CALC
            SelectListItem deleteItem = new SelectListItem();
            foreach (var item in calcMissingMode)
            {
                if (item.Value == "NO_CALC")
                {
                    deleteItem = item;
                    calcMissingMode.Remove(deleteItem);
                    break;
                }
            }
            var SelectList_WorkOffMissingMode = new SelectList(calcMissingMode, "Value", "Text", selectedShiftWorkOffMissingMode);

            ViewBag.MissingWorkOff = SelectList_WorkOffMissingMode;
        }
        private void ShiftMissingLunchStartDropDownList(object selectListCalcMissingMode = null)
        {
            var calcMissingMode = EnumHelperX.GetSelectList<CalcMissingMode>();
            //Exect NO_CALC
            SelectListItem deleteItem = new SelectListItem();
            foreach (var item in calcMissingMode)
            {
                if (item.Value == "NO_CALC")
                {
                    deleteItem = item;
                    calcMissingMode.Remove(deleteItem);
                    break;
                }
            }
            var selectListCalcMissingModes = new SelectList(calcMissingMode, "Value", "Text", selectListCalcMissingMode);

            ViewBag.MissingLunchStart = selectListCalcMissingModes;
        }
        private void ShiftMissingLunchEndDropDownList(object selectListCalcMissingMode = null)
        {
            var calcMissingMode = EnumHelperX.GetSelectList<CalcMissingMode>();
            //Exect NO_CALC
            SelectListItem deleteItem = new SelectListItem();
            foreach (var item in calcMissingMode)
            {
                if (item.Value == "NO_CALC")
                {
                    deleteItem = item;
                    calcMissingMode.Remove(deleteItem);
                    break;
                }
            }
            var selectListCalcMissingModes = new SelectList(calcMissingMode, "Value", "Text", selectListCalcMissingMode);

            ViewBag.MissingLunchEnd = selectListCalcMissingModes;
        }

        private void ShiftMissingOverTimeStartDropDownList(object selectListCalcMissingMode = null)
        {
            var calcMissingMode = EnumHelperX.GetSelectList<CalcMissingMode>();
            //Exect NO_CALC
            SelectListItem deleteItem = new SelectListItem();
            foreach (var item in calcMissingMode)
            {
                if (item.Value == "NO_CALC")
                {
                    deleteItem = item;
                    calcMissingMode.Remove(deleteItem);
                    break;
                }
            }
            var selectListCalcMissingModes = new SelectList(calcMissingMode, "Value", "Text", selectListCalcMissingMode);

            ViewBag.MissingOverTimeStart = selectListCalcMissingModes;
        }
        private void ShiftMissingOverTimeEndDropDownList(object selectListCalcMissingMode = null)
        {
            var calcMissingMode = EnumHelperX.GetSelectList<CalcMissingMode>();
            //Exect NO_CALC
            SelectListItem deleteItem = new SelectListItem();
            foreach (var item in calcMissingMode)
            {
                if (item.Value == "NO_CALC")
                {
                    deleteItem = item;
                    calcMissingMode.Remove(deleteItem);
                    break;
                }
            }
            var selectListCalcMissingModes = new SelectList(calcMissingMode, "Value", "Text", selectListCalcMissingMode);

            ViewBag.MissingOverTimeEnd = selectListCalcMissingModes;
        }
        private void PopulateAssignedWeekDayType(string ShiftId)
        {
            var weekDayTypes = EnumHelperX.GetSelectList<WeekDayType>();
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
            var weekDayTypes = EnumHelperX.GetSelectList<WeekDayType>();
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
                foreach (int myweekday in Enum.GetValues(typeof(WeekDayType)))
                {
                    string ExcludeWeekDay = dbContext.Shift.Find(ShiftId).ExcludeWeekDay;
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