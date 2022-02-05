using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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

        public string GetTableKeyID_DatePeriod(DateTime StartDate, DateTime EndDate)
        {
            string strStartDate = string.Format("{0:yyyyMMdd}", StartDate);
            string strEndDate = EndDate == null ? "" : string.Format("{0:yyyyMMdd}", EndDate);
            string tohash = strStartDate + strEndDate;
            string a = RemoveNumber(SHA1encode(tohash)).Substring(0, 3).ToUpper();
            string NewID = string.Format("{0}{1}{2}", strStartDate, strEndDate, a);

            return NewID;
        }
        

        public static string RemoveNumber(string key)
        {
            return Regex.Replace(key, @"\d", "");
        }
        public string SHA1encode(string txt)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(txt);
            HashAlgorithm hash = HashAlgorithm.Create();
            MemoryStream stream = new MemoryStream(bytes);
            return hash.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
        }
    }
}