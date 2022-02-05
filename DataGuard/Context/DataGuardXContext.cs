using Microsoft.EntityFrameworkCore;

namespace DataGuard.DbFirst
{
    public partial class DataBaseContext : DbContext
    {
        static DataBaseContext()
        {
        }
        public static DataBaseContext Create()
        {
            return new DataBaseContext();
        }
    }
}
