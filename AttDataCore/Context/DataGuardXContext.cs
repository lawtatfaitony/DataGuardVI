using System; 
using Microsoft.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore.Metadata;
using Common;
using ConnectionService; 
namespace AttendanceBussiness.DbFirst
{
    public partial class DataBaseContext : DbContext
    {
        public string GetTableIdentityID(string Prefix, string TableName, int Lenght)
        { 
            AttendanceBussiness.DbFirst.DataBaseContext dbContext = new AttendanceBussiness.DbFirst.DataBaseContext();

            TableIdentity T = new TableIdentity();

            if (dbContext.TableIdentity.Find(TableName) == null)
            {
                T.TableIdentityId = 1;
                T.TableName = TableName;
                T.OperatedDate = DateTime.Now;
                dbContext.TableIdentity.Add(T);
                dbContext.SaveChanges();
            }
            else
            {
                T = dbContext.TableIdentity.Find(TableName);
                T.TableIdentityId += 1;
                T.OperatedDate = DateTime.Now;

                dbContext.Entry(T).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            string NewID = Prefix + T.TableIdentityId.ToString().PadLeft(Lenght, '0');
            return NewID;
        }
       
        public string GetTableKeyID_DatePeriod(DateTime StartDate, DateTime? EndDate, string MainComId)
        {
            string strStartDate = string.Format("{0:yyyyMMdd}", StartDate);
            string strEndDate = EndDate == null ? "" : string.Format("{0:yyyyMMdd}", EndDate);
            string tohash = strStartDate + strEndDate; 
            string a = CommonBase.RemoveNumber(CommonBase.SHA1encode(tohash)).Substring(0, 3).ToUpper();
            string NewID = string.Format("{0}{3}{1}{2}", strStartDate, strEndDate, MainComId, a);

            return NewID;
        }
        public string GetTableKeyID_DatePeriod(DateTime StartDate, DateTime? EndDate, string MainComId, string ShiftAbbrId)
        {
            string strStartDate = string.Format("{0:yyyyMMdd}", StartDate);
            string strEndDate = EndDate == null ? "" : string.Format("{0:yyyyMMdd}", EndDate);
            string a = Common.CommonBase.RemoveNumber(Common.CommonBase.SHA1encode(strStartDate + ShiftAbbrId + strEndDate)).Substring(0, 3).ToUpper();
            string NewID = string.Format("{0}{3}{1}{2}", strStartDate, strEndDate, MainComId, a);

            return NewID;
        }
    }
}
 
