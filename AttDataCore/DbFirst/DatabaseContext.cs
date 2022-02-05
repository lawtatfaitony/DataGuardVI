using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AttendanceBussiness.DbFirst
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AttendanceByCom> AttendanceByCom { get; set; }
        public virtual DbSet<AttendanceByDay> AttendanceByDay { get; set; }
        public virtual DbSet<AttendanceByPeriod> AttendanceByPeriod { get; set; }
        public virtual DbSet<AttendanceByShift> AttendanceByShift { get; set; }
        public virtual DbSet<AttendanceLog> AttendanceLog { get; set; }
        public virtual DbSet<Contractor> Contractor { get; set; }
        public virtual DbSet<DefinitedPeriod> DefinitedPeriod { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<DeviceUser> DeviceUser { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EventLog> EventLog { get; set; }
        public virtual DbSet<Holiday> Holiday { get; set; }
        public virtual DbSet<Industry> Industry { get; set; }
        public virtual DbSet<InfoCate> InfoCate { get; set; }
        public virtual DbSet<InfoDetail> InfoDetail { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Leave> Leave { get; set; }
        public virtual DbSet<MainCom> MainCom { get; set; }
        public virtual DbSet<MenuItem> MenuItem { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }
        public virtual DbSet<Site> Site { get; set; }
        public virtual DbSet<SourceStatistic> SourceStatistic { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<SysModule> SysModule { get; set; }
        public virtual DbSet<TableIdentity> TableIdentity { get; set; }
        public virtual DbSet<TaskJob> TaskJob { get; set; }
        public virtual DbSet<TaskSetting> TaskSetting { get; set; }
        public virtual DbSet<TransferObjectList> TransferObjectList { get; set; }
        public virtual DbSet<UploadItem> UploadItem { get; set; }
        public virtual DbSet<UserTrace> UserTrace { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=CLOUDSERVER\\DATAGUARD;Initial Catalog=DataGuardX1;User ID=admin;Password=admin123;Connect Timeout=300;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;App=EntityFramework;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.IndustryId).HasMaxLength(20);

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AttendanceByCom>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AttendanceByComId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ContractorId).HasMaxLength(128);

                entity.Property(e => e.ContractorName).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.SysCalcDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AttendanceByDay>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AttendanceByDayId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ContractorId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ContractorName).HasMaxLength(50);

                entity.Property(e => e.DayShiftListJson).HasColumnType("ntext");

                entity.Property(e => e.DayShiftNameList).HasColumnType("ntext");

                entity.Property(e => e.DepartmentId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.EmployeeName).HasMaxLength(50);

                entity.Property(e => e.HmacHash)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.HolidayId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HolidayName).HasMaxLength(150);

                entity.Property(e => e.HolidayPaidTypeName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.HolidayWithPaidRatio).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.JobId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.JobName).HasMaxLength(50);

                entity.Property(e => e.LeaveId).HasMaxLength(20);

                entity.Property(e => e.LeavePaidTypeName).HasMaxLength(150);

                entity.Property(e => e.LeaveTypeName).HasMaxLength(150);

                entity.Property(e => e.LeaveWithPaidRatio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OccurDate).HasColumnType("date");

                entity.Property(e => e.OnDutyPaidRatioAvg).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.OnDutyWorkRatioAvg).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PositionId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PositionTitle).HasMaxLength(50);

                entity.Property(e => e.SiteId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.SiteName).HasMaxLength(50);

                entity.Property(e => e.SysCalcDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AttendanceByPeriod>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AccuAbsentDays).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AccuHolidays).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AccuLeaveDays).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AccuWorkDays).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AttendanceByPeriodId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.AvgOnDutyPaidRatio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AvgOnDutyWorkRatio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ContractorId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ContractorName).HasMaxLength(50);

                entity.Property(e => e.DepartmentId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.EmployeeName).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.HmacHash)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.JobName).HasMaxLength(50);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ObjectData).HasColumnType("ntext");

                entity.Property(e => e.PositionId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PositionTitle).HasMaxLength(50);

                entity.Property(e => e.ShiftNameStructure).HasColumnType("ntext");

                entity.Property(e => e.SiteId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.SiteName).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.SysCalcDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AttendanceByShift>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AttendanceByShiftId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.BreakTimeTotalSpan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ContractorId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ContractorName).HasMaxLength(50);

                entity.Property(e => e.DepartmentId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.EmployeeName).HasMaxLength(50);

                entity.Property(e => e.HmacHash)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.HolidayId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HolidayName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.HolidayPaidTypeName).HasMaxLength(150);

                entity.Property(e => e.JobId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.JobName).HasMaxLength(50);

                entity.Property(e => e.LeaveId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LeavePaidTypeName).HasMaxLength(150);

                entity.Property(e => e.LeaveTypeName).HasMaxLength(150);

                entity.Property(e => e.LunchTimeEnd).HasColumnType("datetime");

                entity.Property(e => e.LunchTimeSpan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LunchTimeStart).HasColumnType("datetime");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ObjData).HasColumnType("ntext");

                entity.Property(e => e.OnDutyPaidRatio).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.OnDutyWorkRatio).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.OverTimeEnd).HasColumnType("datetime");

                entity.Property(e => e.OverTimeSpan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OverTimeStart).HasColumnType("datetime");

                entity.Property(e => e.PositionId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PositionTitle).HasMaxLength(50);

                entity.Property(e => e.ScheduleDate).HasColumnType("date");

                entity.Property(e => e.ShiftAbbrId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ShiftId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ShiftName).HasMaxLength(150);

                entity.Property(e => e.SiteId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.SiteName).HasMaxLength(50);

                entity.Property(e => e.SysCalcDateTime).HasColumnType("datetime");

                entity.Property(e => e.WorkActualNetTimeSpan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WorkEnd).HasColumnType("datetime");

                entity.Property(e => e.WorkStart).HasColumnType("datetime");

                entity.Property(e => e.WorkTimeSpan).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<AttendanceLog>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AccesscardId).HasMaxLength(20);

                entity.Property(e => e.CatchPicture).HasColumnType("text");

                entity.Property(e => e.CatchPictureFileName).HasMaxLength(256);

                entity.Property(e => e.CnName).HasMaxLength(128);

                entity.Property(e => e.CompanyName).HasMaxLength(128);

                entity.Property(e => e.ContractorId).HasMaxLength(128);

                entity.Property(e => e.ContractorName).HasMaxLength(128);

                entity.Property(e => e.CratedDateTime).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasMaxLength(128);

                entity.Property(e => e.DepartmentName).HasMaxLength(128);

                entity.Property(e => e.DeviceId).HasMaxLength(128);

                entity.Property(e => e.DeviceName).HasMaxLength(128);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.FacialArea)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FacialAvatar).HasColumnType("text");

                entity.Property(e => e.HmacHash)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.JobId).HasMaxLength(128);

                entity.Property(e => e.JobName).HasMaxLength(128);

                entity.Property(e => e.LatitudeAndLongitude)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ObjData).HasColumnType("ntext");

                entity.Property(e => e.PositionId).HasMaxLength(128);

                entity.Property(e => e.PositionTitle).HasMaxLength(128);

                entity.Property(e => e.SiteId).HasMaxLength(10);

                entity.Property(e => e.SiteName).HasMaxLength(128);
            });

            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ContractorId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceEndDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceStartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DefinitedPeriod>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DefinitedPeriodId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.DefinitedPeriodName).HasMaxLength(50);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OperatedUserName).HasColumnType("datetime");

                entity.Property(e => e.PeriodEndDate).HasColumnType("date");

                entity.Property(e => e.PeriodStartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DepartmentId)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AppId).HasMaxLength(512);

                entity.Property(e => e.AppSecret).HasMaxLength(512);

                entity.Property(e => e.ClientId).HasMaxLength(512);

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeviceSerialNo).HasMaxLength(50);

                entity.Property(e => e.DeviceUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Port)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SiteId).HasMaxLength(10);

                entity.Property(e => e.SiteName).HasMaxLength(50);

                entity.Property(e => e.SysModuleId)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DeviceUser>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AccessCardId).HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeviceId).HasMaxLength(50);

                entity.Property(e => e.DeviceName).HasMaxLength(50);

                entity.Property(e => e.DevidceUserProfileId).HasMaxLength(256);

                entity.Property(e => e.EmployName).HasMaxLength(50);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserIconPositive).HasColumnType("text");

                entity.Property(e => e.UserIconSide).HasColumnType("text");

                entity.Property(e => e.UserIconTopView).HasColumnType("text");

                entity.Property(e => e.UserId).HasMaxLength(128);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AccessCardId).HasMaxLength(128);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CnName).HasMaxLength(128);

                entity.Property(e => e.CompanyName).HasMaxLength(128);

                entity.Property(e => e.ContractorId).HasMaxLength(128);

                entity.Property(e => e.ContractorName).HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasMaxLength(128);

                entity.Property(e => e.DepartmentName).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");

                entity.Property(e => e.FingerPrint).HasMaxLength(128);

                entity.Property(e => e.FirstName).HasMaxLength(128);

                entity.Property(e => e.IdNumber).HasMaxLength(128);

                entity.Property(e => e.JobId).HasMaxLength(128);

                entity.Property(e => e.JobName).HasMaxLength(128);

                entity.Property(e => e.LastName).HasMaxLength(128);

                entity.Property(e => e.LeaveDate).HasColumnType("datetime");

                entity.Property(e => e.MainComId).HasMaxLength(128);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(128);

                entity.Property(e => e.ParentUserId).HasMaxLength(128);

                entity.Property(e => e.PhoneNumber).HasMaxLength(128);

                entity.Property(e => e.PositionId).HasMaxLength(128);

                entity.Property(e => e.PositionTitle).HasMaxLength(128);

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.SiteId).HasMaxLength(128);

                entity.Property(e => e.SiteName).HasMaxLength(128);

                entity.Property(e => e.The3rdPartyEmployeeId).HasMaxLength(128);

                entity.Property(e => e.UserIcon).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);
            });

            modelBuilder.Entity<EventLog>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EventDatetime).HasColumnType("datetime");

                entity.Property(e => e.EventLogId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MessageIfException).HasMaxLength(2000);

                entity.Property(e => e.OperateDatetime).HasColumnType("datetime");

                entity.Property(e => e.OperateLogContent).HasColumnType("ntext");

                entity.Property(e => e.OperateUserName)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.HolidayCnName).HasMaxLength(150);

                entity.Property(e => e.HolidayDate).HasColumnType("date");

                entity.Property(e => e.HolidayEnName).HasMaxLength(150);

                entity.Property(e => e.HolidayId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HolidayPaidTypeName).HasMaxLength(50);

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.OnDutyPaidRatio).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IndustryId)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<InfoCate>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.InfoCateId)
                    .IsRequired()
                    .HasColumnName("InfoCateID")
                    .HasMaxLength(128);

                entity.Property(e => e.InfoCateName).HasMaxLength(50);

                entity.Property(e => e.LanguageCode).HasMaxLength(20);

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(128);

                entity.Property(e => e.PrarentsId)
                    .HasColumnName("PrarentsID")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<InfoDetail>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Author).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InfoCateId).HasMaxLength(6);

                entity.Property(e => e.InfoDescription).HasColumnType("ntext");

                entity.Property(e => e.InfoId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.InfoItemTemplateIds).HasMaxLength(256);

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.SeoDescription).HasMaxLength(256);

                entity.Property(e => e.SeoKeyword).HasMaxLength(256);

                entity.Property(e => e.StaffId).HasMaxLength(128);

                entity.Property(e => e.SubTitle).HasMaxLength(512);

                entity.Property(e => e.Title).HasMaxLength(256);

                entity.Property(e => e.TitleThumbNail).HasMaxLength(256);

                entity.Property(e => e.UserTraceId).HasMaxLength(128);

                entity.Property(e => e.VideoUrl).HasMaxLength(512);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.JobId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EnUs).HasColumnName("en_US");

                entity.Property(e => e.KeyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ZhCn).HasColumnName("zh_CN");

                entity.Property(e => e.ZhHk).HasColumnName("zh_HK");
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ApplovedBy).HasMaxLength(50);

                entity.Property(e => e.ApprovedRemarks).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EmployeeName).HasMaxLength(50);

                entity.Property(e => e.LeaveEndDate).HasColumnType("datetime");

                entity.Property(e => e.LeaveId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LeaveStartDate).HasColumnType("datetime");

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.OperatedUserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Reason).HasMaxLength(300);

                entity.Property(e => e.TotalDays).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<MainCom>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CicReferenceNo).HasColumnName("CIC_ReferenceNo");

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 7)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 7)");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceEndDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceStartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.MenuItemId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ParentsNodeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PositionId)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.IdOfMonthlyShiftEmploy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ScheduleDate).HasColumnType("date");

                entity.Property(e => e.ScheduleId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ShiftAbbrId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ShiftId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.SysCalcDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AppliedEndDate).HasColumnType("date");

                entity.Property(e => e.AppliedStartDate).HasColumnType("date");

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentIdArr).HasMaxLength(500);

                entity.Property(e => e.ExcludeOverTime).HasMaxLength(50);

                entity.Property(e => e.ExcludeWeekDay).HasMaxLength(50);

                entity.Property(e => e.IconColor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LunchTimeSpan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OperatedUserName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.OverTimeSpan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RuleDescription).HasMaxLength(600);

                entity.Property(e => e.ShiftAbbrId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ShiftId)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ShiftName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SpecialWeekDays).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WorkTimeSpan).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SiteAddress).HasMaxLength(50);

                entity.Property(e => e.SiteId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SiteName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SourceStatistic>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Duration).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("IP")
                    .HasMaxLength(128);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LoadTime).HasColumnName("loadTime");

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.OpenId).HasMaxLength(256);

                entity.Property(e => e.Osversion)
                    .HasColumnName("OSVersion")
                    .HasMaxLength(128);

                entity.Property(e => e.RecommUserId).HasMaxLength(128);

                entity.Property(e => e.SourceArea).HasMaxLength(256);

                entity.Property(e => e.TableKeyId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Title).HasMaxLength(256);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.VisitorIcon).HasMaxLength(256);

                entity.Property(e => e.WxNickName).HasMaxLength(50);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ChannelId)
                    .HasColumnName("ChannelID")
                    .HasMaxLength(256);

                entity.Property(e => e.ContactTitle).HasMaxLength(100);

                entity.Property(e => e.IconPortrait).HasMaxLength(256);

                entity.Property(e => e.Introduction).HasColumnType("ntext");

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.OtherChannelName).HasMaxLength(256);

                entity.Property(e => e.OtherQrcode).HasMaxLength(256);

                entity.Property(e => e.PublicNo).HasMaxLength(300);

                entity.Property(e => e.Qrcode).HasMaxLength(256);

                entity.Property(e => e.StaffId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.StaffName).HasMaxLength(256);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.UserName).HasMaxLength(128);
            });

            modelBuilder.Entity<SysModule>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AppId).HasMaxLength(512);

                entity.Property(e => e.AppSecret).HasMaxLength(512);

                entity.Property(e => e.ClientId).HasMaxLength(512);

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Port)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SiteId).HasMaxLength(10);

                entity.Property(e => e.SiteName).HasMaxLength(50);

                entity.Property(e => e.SyncTargetPath)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.SysModuleId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SysModuleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SysModuleUrl).HasMaxLength(500);
            });

            modelBuilder.Entity<TableIdentity>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<TaskJob>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CompletedDatetime).HasColumnType("datetime");

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TargetTalbeKeyId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TaskJobId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TriggerDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TaskSetting>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.TaskRemarks).HasMaxLength(250);

                entity.Property(e => e.TaskSettingId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TaskStartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TransferObjectList>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.HolderId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.HolderName).HasMaxLength(128);

                entity.Property(e => e.HolderRfId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ObjectId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ObjectName).HasMaxLength(128);

                entity.Property(e => e.ObjectRfId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TransferObjectListId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UploadItem>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FileExt).HasMaxLength(20);

                entity.Property(e => e.MainComId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.RawName).HasMaxLength(100);

                entity.Property(e => e.SubPath).HasMaxLength(256);

                entity.Property(e => e.TargetTalbeKeyId).HasMaxLength(256);

                entity.Property(e => e.UploadItemId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Url).HasMaxLength(256);
            });

            modelBuilder.Entity<UserTrace>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.MainComId).HasMaxLength(20);

                entity.Property(e => e.OperatedDate).HasColumnType("datetime");

                entity.Property(e => e.OperatedUserName).HasMaxLength(256);

                entity.Property(e => e.TableKeyId)
                    .HasColumnName("TableKeyID")
                    .HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.UserTraceId)
                    .IsRequired()
                    .HasColumnName("UserTraceID")
                    .HasMaxLength(128);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
