using DataGuard.Context;
using LanguageResource;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AttendanceBussiness.ShiftBusiness;

namespace DataGuard.Models.BusinessDataModel
{
    //public enum Genders
    //{
    //    Male = 1, Female = 2, Unkown = 3  // 男;女;未知
    //}
    public class Employee
    {
        #region  logic calc

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [LocalizedDisplayName("ID", KeyName = "Employee_EmployeeID", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        [Column(TypeName = "Nvarchar", Order = 0)]
        public string EmployeeID { get; set; }

        [LocalizedDisplayName("The 3rd Party EmployeeID", KeyName = "Employee_The3rdPartyEmployeeID", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        [Column(TypeName = "Nvarchar", Order = 1)]
        public string The3rdPartyEmployeeID { get; set; }

        [LocalizedDisplayName("UserId", KeyName = "Employee_UserId", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        [Column(TypeName = "Nvarchar", Order = 2)]
        public string UserId { get; set; }

        [LocalizedDisplayName("ParentUserId", KeyName = "Employee_ParentUserId", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        [Column(TypeName = "Nvarchar", Order = 3)]
        public string ParentUserId { get; set; }

        #endregion


        #region Employee基因资料

        [LocalizedDisplayName("UserIcon", KeyName = "Employee_UserIcon", KeyType = KeyType.Modal)]
        [MaxLength(512)]
        [Column(TypeName = "varchar", Order = 4)]
        public string UserIcon { get; set; }

        [LocalizedDisplayName("英文名", KeyName = "Employee_FirstName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar", Order = 5)]
        public string FirstName { get; set; }

        [LocalizedDisplayName("LastName", KeyName = "Employee_LastName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar", Order = 6)]
        public string LastName { get; set; }

        [LocalizedDisplayName("姓名", KeyName = "Employee_CnName", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        [Column(TypeName = "Nvarchar", Order = 7)]
        public string CnName { get; set; }

        [LocalizedDisplayName("性别", KeyName = "Employee_Gender ", KeyType = KeyType.Modal)]
        [DefaultValue(Genders.Unkown)]
        public AttendanceBussiness.ShiftBusiness.Genders Gender { get; set; }

        [LocalizedDisplayName("出生日期", KeyName = "Employee_Birthday", KeyType = KeyType.Modal)]
        [Column(TypeName = "datetime", Order = 8)]
        [DefaultValue(typeof(DateTime), "")]
        public DateTime Birthday { get; set; }

        [LocalizedDisplayName("手机", KeyName = "Employee_PhoneNumber", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "varchar", Order = 9)]
        public string PhoneNumber { get; set; }

        [LocalizedDisplayName("Email", KeyName = "Employee_Email", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        [Column(TypeName = "Nvarchar", Order = 10)]
        public string Email { get; set; }

        #endregion

        #region Employee系统数据

        [LocalizedDisplayName("公司ID", KeyName = "Employee_MainComId", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "Nvarchar", Order = 11)]
        public string MainComId { get; set; }

        [Required]
        [LocalizedDisplayName("公司名称", KeyName = "MainCom_CompanyName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string CompanyName { get; set; }


        [LocalizedDisplayName("所属于第三方", KeyName = "Employee_ContractorId", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "Nvarchar", Order = 12)]

        public string ContractorId { get; set; }

        [LocalizedDisplayName("The 3Rd 服务公司名称", KeyName = "Employee_ContractorName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string ContractorName { get; set; }

        [LocalizedDisplayName("SiteId", KeyName = "Employee_SiteId", KeyType = KeyType.Modal)]
        [MaxLength(3)]
        [Column(TypeName = "Nvarchar", Order = 12)]

        public string SiteId { get; set; }

        [LocalizedDisplayName("地盤名稱", KeyName = "Employee_SiteName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string SiteName { get; set; }


        [LocalizedDisplayName("通行卡ID", KeyName = "Employee_AccessCardId", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "Nvarchar", Order = 13)]
        public string AccessCardId { get; set; }

        [LocalizedDisplayName("入职日期", KeyName = "Employee_EnrollmentDate", KeyType = KeyType.Modal)]
        [Column(TypeName = "datetime", Order = 14)]
        [DefaultValue(typeof(DateTime), "")]
        public DateTime EnrollmentDate { get; set; }

        [LocalizedDisplayName("离职日期", KeyName = "Employee_LeaveDate", KeyType = KeyType.Modal)]
        [Column(TypeName = "datetime", Order = 15)]
        [DefaultValue(typeof(DateTime), "")]
        public DateTime LeaveDate { get; set; }

        [LocalizedDisplayName("备注", KeyName = "Employee_Remarks", KeyType = KeyType.Modal)]
        [MaxLength(500)]
        [Column(TypeName = "Nvarchar", Order = 16)]
        public string Remarks { get; set; }

        [LocalizedDisplayName("操作用户", KeyName = "Employee_OperatedUserName", KeyType = KeyType.Modal)]
        [StringLength(256)]
        [Column(TypeName = "Nvarchar", Order = 17)]
        public string OperatedUserName { get; set; }

        [LocalizedDisplayName("创建日期", KeyName = "Employee_CreatedDate", KeyType = KeyType.Modal)]
        [Column(TypeName = "datetime", Order = 18)]
        [DefaultValue(typeof(DateTime), "")]
        public DateTime CreatedDate { get; set; }

        [LocalizedDisplayName("操作日期", KeyName = "Employee_OperatedDate", KeyType = KeyType.Modal)]
        [Column(TypeName = "datetime", Order = 19)]
        [DefaultValue(typeof(DateTime), "")]
        public DateTime OperatedDate { get; set; }

        [LocalizedDisplayName("拉黑", KeyName = "Employee_IsBlock", KeyType = KeyType.Modal)]
        [DefaultValue(false)]
        public bool IsBlock { get; set; }

        #endregion
    }
}