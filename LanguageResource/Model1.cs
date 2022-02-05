 
namespace LanguageResource
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using LanguageResource.Modal;
    using ConnectionService;

    public partial class Model1 : DbContext
    { 
        public Model1()
        : base(ConnectComponent.ConnectiongString)  //  : base(ConnectComponent.ConnectiongString, throwIfV1Schema: false)  new SQLiteConnection(Config.Config.getDatabaseConnStr()),true/*"name=LocalDb"*/ // "name=DataGuardDBContext"
        {
        }

        public virtual DbSet<Language> Languages { get; set; }
        
    }
}
