using DataGuard.Context;
using LanguageResource;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataGuard.Models.PubDataModel
{
    public class Industry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [LocalizedDisplayName("Industry Id", KeyName = "Industry_IndustryId", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "Nvarchar")]
        public string IndustryId { get; set; }

        [Required]
        [LocalizedDisplayName("Industry Name", KeyName = "Industry_IndustryName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string IndustryName { get; set; }

        [LocalizedDisplayName("Industry Name", KeyName = "Industry_EnIndustryName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string EnIndustryName { get; set; }

        [Required]
        [LocalizedDisplayName("Parents Id", KeyName = "Industry_ParentsIndustryId", KeyType = KeyType.Modal)]
        [DefaultValue(0)]
        public int ParentsIndustryId { get; set; }
    }
    /// <summary>
    /// 行業職位 如：經理 師傅
    /// </summary>
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [LocalizedDisplayName("Position Id", KeyName = "Position_PositionId", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "Nvarchar")]
        public string PositionId { get; set; }

        [Required]
        [LocalizedDisplayName("Industry Id", KeyName = "Position_IndustryId", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "Nvarchar")]
        public string IndustryId { get; set; }

        [Required]
        [LocalizedDisplayName("Industry Name", KeyName = "Position_IndustryName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string IndustryName { get; set; }

        [Required]
        [LocalizedDisplayName("Position Title", KeyName = "Position_PositionTitle", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string PositionTitle { get; set; }

        [LocalizedDisplayName("Position Eng Title", KeyName = "Position_EnPositionTitle", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string EnPositionTitle { get; set; }

        [LocalizedDisplayName("CreatedDate", KeyName = "Position_CreatedDate", KeyType = KeyType.Modal)]
        [DefaultValue(typeof(DateTime), "")]
        public DateTime CreatedDate { get; set; }

    }
}





