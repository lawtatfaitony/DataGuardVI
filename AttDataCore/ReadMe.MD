Microsoft.EntityFrameworkCore.Tools  v3.12
Microsoft.EntityFrameworkCore.SqlServer v3.12
Microsoft.EntityFrameworkCore.Design v3.12
Microsoft.EntityFrameworkCore.Abstractions v3.12
Microsoft.EntityFrameworkCore v3.12

Scaffold-DbContext "Data Source=(local)\DATAGUARD;Initial Catalog=DataGuardX;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;App=EntityFramework;" Microsoft.EntityFrameworkCore.SqlServer -force -OutputDir Models -Context DatabaseContext -ContextNamespace AttendanceBussiness.DbFirst

这句对的。

Scaffold-DbContext "Data Source=(local)\DATAGUARD;Initial Catalog=DataGuardXcore;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;App=EntityFramework;" Microsoft.EntityFrameworkCore.SqlServer -force -OutputDir Models -Context DatabaseContext

OK as follows :
 Scaffold-DbContext "Data Source=STARON\DATAGUARDSRV;Initial Catalog=DataGuardXcore;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;App=EntityFramework;" Microsoft.EntityFrameworkCore.SqlServer -force -OutputDir Models -Context DataBaseContext

创建数据迁移：

dotnet ef migrations add InitialCreate
Build started...
Build succeeded.
Done. To undo this action, use 'ef migrations remove'

通过  'ef migrations remove' 移除数据迁移



数据迁移 OK 测试验收通过版本！！！！ 


注意：
JSONDATA 文件夹下的json 如果存在则执行这里的数据同步到数据库，否则执行程序代码的。
可以暂时把json文件改名，避开执行jsaon。

数据库实例名称Instance Name：DATAGUARD
必须创建null的数据库 DataGuard123 
连接串账户：admin
密码：admin123

创建的系统登录账户保存在应用程序目录下的 Account_xxxxx.txt文件。

====================================================================================================================
Nutget控制台下输入命令：
PM> dotnet ef migrations add InitialCreate -c DatabaseContext
出现的问题
No project was found. Change the current working directory or use the --project option.
解决：
dotnet ef migrations script --verbose -i --project "D:\STARXXX\DataGuard\DataBaseInitialCreate\DataBaseInitialCreate.csproj"  【这句test ok】

 dotnet --project "D:\STARON\DataGuard\DataBaseInitialCreate\DataBaseInitialCreate.csproj"  ef migrations add InitialMigration

 解决II:
 在cmd命令下，cd 转到proj所在文件夹下，输入命令：
 dotnet ef migrations add InitialCreate
前提要保证 项目Build 生成成功。


 //========================================================================================================
 连接串是独立程序集的写法：

 解决：如果DBContext和启动程序不在一个程序集，需要指定要迁移的程序集。代码中添加要迁移的程序集名称：

 在文件 【DatabaseContext.cs】 把对应的连接串改为如下：
 options.UseSqlServer(connection, b => b.MigrationsAssembly("Do.TmsApi"))

 来源：https://www.cnblogs.com/gaozejie/p/12422112.html

 //=======================================================================================================
 CMD Console 控制台命令实现数据库移植：

 F:\STAR\DataGuard\DataBaseInitialCreate\DataBaseInitialCreate>dotnet ef migrations add InitialDatabase
Build started...
Build succeeded.
Done. To undo this action, use 'ef migrations remove'
 