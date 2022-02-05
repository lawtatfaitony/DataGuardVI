using AttendanceBussiness.DbFirst;
using Common;
using Newtonsoft.Json;
using StarGateway;
using StarGateway.GateWay;
using StarGateway.ModelApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace TaskStarGateWay
{
    class Program
    { 
        static void Main(string[] args)
        {  

            CWRG cWRG  = new CWRG();
            ReturnTokenObj returnTokenObj = cWRG.InitializeSecurityToken();
            Console.WriteLine(JsonConvert.SerializeObject(returnTokenObj,Formatting.Indented));
            List<Contract> contracts = cWRG.GetContractNoByAccount();
            if(contracts==null)
            {
                CommonBase.OperateDateLoger("[TaskStarGateWay.exe] [List<Contract> contracts = null]");
                return;
            }
            List<GoodList> goodAllLists = new List<GoodList>();
            if (contracts.Count != 0)
            {
                foreach (var item in contracts)
                {
                    List<GoodList> goodLists = cWRG.GetGoodList(item.RowId, "20160401000000000"); //1417
                    string strGoodList = JsonConvert.SerializeObject(goodLists, Formatting.Indented);
                    goodAllLists.AddRange(goodLists);
                    Console.WriteLine(strGoodList);
                }
            }
            List<StarGateway.ModelApi.SynchronizeView> synchronizeViews = new List<StarGateway.ModelApi.SynchronizeView>();
            foreach (var item in goodAllLists)
            { 
                Employee employee = new Employee
                {
                    EmployeeId =string.Empty,
                    The3rdPartyEmployeeId = item.CwrNo?? string.Empty,
                    UserId=string.Empty,
                    ParentUserId = string.Empty,
                    UserIcon = string.Empty,
                    FirstName= NameCls.SplitName(item.NameEng).FirtName,
                    LastName = NameCls.SplitName(item.NameEng).LastName,
                    CnName=item.NameChi,
                    Gender=3,
                    IdNumber = item.IdNumber,
                    Birthday = DateTime.Now,
                    PhoneNumber = string.Empty,
                    Email = string.Empty,
                    MainComId = string.Empty,
                    CompanyName = string.Empty,
                    ContractorId = item.ContractID,
                    ContractorName = string.Empty,
                    SiteId = string.Empty,
                    SiteName = string.Empty,
                    DepartmentId = string.Empty,
                    DepartmentName = string.Empty,
                    JobId = string.Empty,
                    JobName = string.Empty,
                    PositionId = string.Empty,
                    PositionTitle = string.Empty,
                    AccessCardId = item.CwrNo,
                    FingerPrint =  string.Empty,
                    EnrollmentDate = DateTime.Now,
                    LeaveDate = DateTime.Now,
                    Remarks ="123456789123456789",
                    OperatedUserName = "SYSTEM",
                    CreatedDate =DateTime.Now,
                    OperatedDate =DateTime.Now,
                    IsBlock = false
                };

                InsertX(employee);
            }

            
            while(true)
            {
                Console.ReadKey();
            } 
        } 

        public static void InsertX(Employee employee)
        {
            using (DataBaseContext dataBaseContext = new DataBaseContext())
            {
                employee.EmployeeId = dataBaseContext.GetTableIdentityID("E","Employee",4);
                dataBaseContext.Employee.Add(employee);
                bool result = dataBaseContext.SaveChanges()>0;

                if(result)
                    Console.WriteLine("INSERT SUCCESS");
                else
                    Console.WriteLine("UPDATE FAIL");
            }
        }
    } 
}
