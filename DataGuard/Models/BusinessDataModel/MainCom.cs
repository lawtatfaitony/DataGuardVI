using DataGuard.Context;
using LanguageResource;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataGuard.Models.BusinessDataModel
{
    public class MainCom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [LocalizedDisplayName("MainComId", KeyName = "MainCom_MainComId", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "Nvarchar")]
        public string MainComId { get; set; }

        [Required]
        [LocalizedDisplayName("公司名称", KeyName = "MainCom_CompanyName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string CompanyName { get; set; }

        [LocalizedDisplayName("公司简称", KeyName = "MainCom_CompanyAbbreviation", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string CompanyAbbreviation { get; set; }

        [Required]
        [LocalizedDisplayName("行业Id", KeyName = "MainCom_IndustryId", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "Nvarchar")]
        public string IndustryId { get; set; }

        [Required]
        [LocalizedDisplayName("所属行业", KeyName = "MainCom_IndustryName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string IndustryName { get; set; }

        [LocalizedDisplayName("公司联系人", KeyName = "MainCom_ContactName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string ContactName { get; set; }

        [LocalizedDisplayName("联系人手机", KeyName = "MainCom_ContactPhone", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string ContactPhone { get; set; }

        [LocalizedDisplayName("公司电话", KeyName = "MainCom_CompanyTel", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string CompanyTel { get; set; }

        [LocalizedDisplayName("公司传真", KeyName = "MainCom_CompanyFax", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string CompanyFax { get; set; }

        [LocalizedDisplayName("公司Logo", KeyName = "MainCom_CompanyNameLogo", KeyType = KeyType.Modal)]
        [MaxLength(200)]
        [Column(TypeName = "Nvarchar")]
        public string CompanyLogo { get; set; }

        [LocalizedDisplayName("CIC Reference No.", KeyName = "MainCom_CIC_ReferenceNo", KeyType = KeyType.Modal)]
        [Column(TypeName = "Nvarchar")]
        [MaxLength(20)]
        public string CIC_ReferenceNo { get; set; }

        [LocalizedDisplayName("合约编号", KeyName = "MainCom_ContractorNo", KeyType = KeyType.Modal)]
        [Column(TypeName = "Nvarchar")]
        [MaxLength(30)]
        public string ContractorNo { get; set; }

        [LocalizedDisplayName("服務開始日期", KeyName = "MainCom_ServiceStartDate", KeyType = KeyType.Modal)]  //使用本軟件的服務
        [DefaultValue(typeof(DateTime), "")]
        [Column(TypeName = "datetime")]
        public DateTime ServiceStartDate { get; set; }

        [LocalizedDisplayName("服務結束日期", KeyName = "MainCom_ServiceEndDate", KeyType = KeyType.Modal)]
        [DefaultValue(typeof(DateTime), "")]
        [Column(TypeName = "datetime")]
        public DateTime ServiceEndDate { get; set; }

        [LocalizedDisplayName("经度", KeyName = "MainCom_Longitude", KeyType = KeyType.Modal)]
        [Column(TypeName = "decimal")]
        public Decimal Longitude { get; set; }

        [LocalizedDisplayName("纬度", KeyName = "MainCom_Latitude", KeyType = KeyType.Modal)]
        [Column(TypeName = "decimal")]
        public Decimal Latitude { get; set; }

        [LocalizedDisplayName("公司地址", KeyName = "MainCom_CompanyAddress", KeyType = KeyType.Modal)]
        [MaxLength(250)]
        [Column(TypeName = "Nvarchar")]
        public string CompanyAddress { get; set; }

        [LocalizedDisplayName("操作用户", KeyName = "MainCom_OperatedUserName", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        [Column(TypeName = "Nvarchar")]
        public string OperatedUserName { get; set; }

        [LocalizedDisplayName("操作日期", KeyName = "MainCom_OperatedDate", KeyType = KeyType.Modal)]
        [Column(TypeName = "datetime")]
        [DefaultValue(typeof(DateTime), "")]
        public DateTime OperatedDate { get; set; }

        [LocalizedDisplayName("服務狀態", KeyName = "MainCom_ServiceStatus", KeyType = KeyType.Modal)]
        [DefaultValue(MainComServiceStatus.NotInUsed)]
        public MainComServiceStatus ServiceStatus { get; set; }
    }

    public enum MainComServiceStatus
    {
        NotInUsed = -1, ServiceTry = 0, OnService = 1, EndOfService = 2, ServiceSuspension = 3  //使用系統的服務狀態
    }
    public class Contractor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [LocalizedDisplayName("ContractorId", KeyName = "Contractor_MainComId", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "Nvarchar")]
        public string ContractorId { get; set; }

        [Required]
        [LocalizedDisplayName("The 3Rd 服务公司名称", KeyName = "Contractor_CompanyName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string ContractorName { get; set; }

        [LocalizedDisplayName("合约编号", KeyName = "Contractor_ContractorNo", KeyType = KeyType.Modal)]
        [Column(TypeName = "Nvarchar")]
        [MaxLength(30)]
        public string ContractorNo { get; set; }

        [Required]
        [LocalizedDisplayName("行业Id", KeyName = "Contractor_IndustryId", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "Nvarchar")]
        public string IndustryId { get; set; }

        [Required]
        [LocalizedDisplayName("所属行业", KeyName = "Contractor_IndustryName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string IndustryName { get; set; }

        [LocalizedDisplayName("公司联系人", KeyName = "Contractor_ContactName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string ContactName { get; set; }

        [LocalizedDisplayName("联系人手机", KeyName = "Contractor_ContactPhone", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string ContactPhone { get; set; }

        [LocalizedDisplayName("公司电话", KeyName = "Contractor_CompanyTel", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string CompanyTel { get; set; }

        [LocalizedDisplayName("公司传真", KeyName = "Contractor_CompanyFax", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string CompanyFax { get; set; }

        [LocalizedDisplayName("公司Logo", KeyName = "Contractor_CompanyNameLogo", KeyType = KeyType.Modal)]
        [MaxLength(200)]
        [Column(TypeName = "Nvarchar")]
        public string CompanyNameLogo { get; set; }

        [LocalizedDisplayName("服务启动日期", KeyName = "Contractor_ServiceStartDate", KeyType = KeyType.Modal)]
        [Column(TypeName = "datetime")]
        [DefaultValue(typeof(DateTime), "")]
        public DateTime ServiceStartDate { get; set; }

        [LocalizedDisplayName("服务结束日期", KeyName = "Contractor_ServiceEndDate", KeyType = KeyType.Modal)]
        [Column(TypeName = "datetime")]
        [DefaultValue(typeof(DateTime), "")]
        public DateTime ServiceEndDate { get; set; }

        [LocalizedDisplayName("公司地址", KeyName = "Contractor_CompanyAddress", KeyType = KeyType.Modal)]
        [MaxLength(250)]
        [Column(TypeName = "Nvarchar")]
        public string CompanyAddress { get; set; }

        [LocalizedDisplayName("操作用户", KeyName = "Contractor_OperatedUserName", KeyType = KeyType.Modal)]
        [MaxLength(128)]
        [Column(TypeName = "Nvarchar")]
        public string OperatedUserName { get; set; }

        [LocalizedDisplayName("操作日期", KeyName = "Contractor_OperatedDate", KeyType = KeyType.Modal)]
        [Column(TypeName = "datetime")]
        [DefaultValue(typeof(DateTime), "")]
        public DateTime OperatedDate { get; set; }
    }
}

