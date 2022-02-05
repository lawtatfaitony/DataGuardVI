using AttendanceBussiness.DbFirst;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using static AttendanceBussiness.ShiftBusiness;

namespace AttendanceBussiness.MainComAndDefaultOrgData
{
    public partial class MainComBusiness
    {
        public MainCom Create(MainComCreateView mainComCreateView)
        {
            using(DataBaseContext dataBaseContext = new DataBaseContext())
            {
                mainComCreateView.MainComId = dataBaseContext.GetTableIdentityID("M", "MainCom", 6);
                Industry industry = dataBaseContext.Industry.Find(mainComCreateView.IndustryId);
                if(industry==null)
                {
                    return null;
                }
                MainCom mainCom = new MainCom
                {
                    MainComId = mainComCreateView.MainComId,
                    CompanyName = mainComCreateView.CompanyName,
                    CompanyAbbreviation = string.Empty,
                    IndustryId = industry.IndustryId,
                    IndustryName = industry.IndustryName,
                    ContactName = mainComCreateView.ContactName,
                    ContactPhone = mainComCreateView.ContactPhone,
                    CompanyTel = mainComCreateView.CompanyTel,
                    CompanyFax = string.Empty,
                    CompanyLogo = string.Empty,
                    CicReferenceNo = string.Empty,
                    ContractorNo = string.Empty,
                    ServiceStartDate = DateTime.Now,
                    ServiceEndDate = DateTime.Now.AddYears(1),
                    Longitude = 0,
                    Latitude =0,
                    CompanyAddress = mainComCreateView.CompanyAddress,
                    OperatedUserName = mainComCreateView.OperatedUserName,
                    OperatedDate = mainComCreateView.OperatedDate,
                    ServiceStatus = mainComCreateView.ServiceStatus
                };
                dataBaseContext.Add(mainCom);
                bool result = dataBaseContext.SaveChanges() > 0 ? true : false;
                if (result)
                    return mainCom;
                else
                    return null;
            }
        }

        public bool UpdateCoordinate(MainComCoordinate mainComCoordinate)
        {
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                MainCom mainCom = dataBaseContext.MainCom.Find(mainComCoordinate.MainComId);

                if(mainComCoordinate.Latitude == mainComCoordinate.Longitude || mainComCoordinate.Latitude == 0 || mainComCoordinate.Longitude == 0)
                {
                    return false;
                }
                if(mainCom==null)
                {
                    return false;
                }
                mainCom.Latitude = mainComCoordinate.Latitude;
                mainCom.Longitude = mainComCoordinate.Longitude;

                dataBaseContext.Update(mainCom);
                bool result = dataBaseContext.SaveChanges() > 0 ? true : false;
                if (result)
                    return true;
                else
                    return false;
            }
        }
    }

    public partial class MainComCreateView
    {
        public string MainComId { get; set; }
        public string CompanyName { get; set; }
        public string IndustryId { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string CompanyTel { get; set; }
        public string CompanyAddress { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; } = DateTime.Now;
        public int ServiceStatus { get; set; } = (int)MainComServiceStatus.ON_SERVICE;
    }

    public partial class MainComCoordinate
    {
        public string MainComId { get; set; } 
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    }
}
