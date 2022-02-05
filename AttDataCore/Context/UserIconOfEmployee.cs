using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AttendanceBussiness.DbFirst;
using Common;

namespace AttDataSupport.Context
{
    public class UserIconOfEmployee
    {
        public UserIconOfEmployee(string EmployeeId)
        {
            if (string.IsNullOrEmpty(EmployeeId))
            {
                _EmployeeId = "";
                _UserIcon1 = string.Empty;
                _UserIcon2 = string.Empty;
                _UserIcon3 = string.Empty;
            }
            else
            {
                _EmployeeId = EmployeeId;

                List<UploadItem> uploadItems = new List<UploadItem>();
                Employee employee = new Employee();
                if (MemoryCacheHelper.Contains("uploadItems") == false)
                {
                    using (DataBaseContext dataBaseContext = new DataBaseContext())
                    {
                        employee = dataBaseContext.Employee.Find(EmployeeId);
                        uploadItems = dataBaseContext.UploadItem.ToList();
                    }

                    DateTimeOffset thisOffsetTime = DateTime.Now.AddDays(1);
                    MemoryCacheHelper.Set("uploadItems", uploadItems, thisOffsetTime);
                }
                else
                {
                    uploadItems = MemoryCacheHelper.GetCacheItem<List<UploadItem>>("uploadItems");
                }



                if (employee != null)
                {
                    _EmployeeId = EmployeeId;
                    //initialize 
                    _UserIcon1 = string.Empty;
                    _UserIcon2 = string.Empty;
                    _UserIcon3 = string.Empty;


                    uploadItems = uploadItems.Where(c => c.TargetTalbeKeyId.Contains(EmployeeId)).OrderByDescending(c => c.OperatedDate).OrderByDescending(c => c.RankOrder).Take(3).ToList();
                    int i = 0;
                    foreach (var item in uploadItems)
                    {
                        i++;
                        switch (i)
                        {
                            case 1:
                                _UserIcon1 = item.Url;
                                break;
                            case 2:
                                _UserIcon2 = item.Url;
                                break;
                            case 3:
                                _UserIcon3 = item.Url;
                                break;
                        }

                    }
                }
                else
                {
                    _EmployeeId = string.Empty;
                    _UserIcon1 = string.Empty;
                    _UserIcon2 = string.Empty;
                    _UserIcon3 = string.Empty;
                }

            }

        }
        private string _EmployeeId;
        public string EmployeeId
        {
            get
            {
                return _EmployeeId;
            }
            set
            {
                _EmployeeId = value;
            }
        }

        private string _UserIcon1;
        public string UserIcon1
        {
            get
            {
                return _UserIcon1;
            }
            set
            {
                _UserIcon1 = value;
            }
        }

        private string _UserIcon2;
        public string UserIcon2
        {
            get
            {
                return _UserIcon2;
            }
            set
            {
                _UserIcon2 = value;
            }
        }

        private string _UserIcon3;
        public string UserIcon3
        {
            get
            {
                return _UserIcon3;
            }
            set
            {
                _UserIcon3 = value;
            }
        }
    }
}
