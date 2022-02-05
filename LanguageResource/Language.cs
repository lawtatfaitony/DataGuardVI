namespace LanguageResource.Modal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// 多语言  zh(中文地区): zh-TW(台湾) zh-CN(大陆) zh-HK(香港) zh-SG(新加波) zh-MO(澳门) 
    ///         参考代码:https://msdn.microsoft.com/zh-cn/library/kx54z3k7(VS.80).aspx
    /// </summary>
    [Table("Language")]
    public partial class Language
    {
        [Key]
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        [Display(Name = "Key Name", Order = 0)]
        public string KeyName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        [Display(Name = "Key Type", Order = 1)]
        public string KeyType { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "Nvarchar")]
        [Display(Name = "Simplify", Order = 2)]
        public string zh_CN { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "Nvarchar")]
        [Display(Name = "Traditional", Order = 3)]
        public string zh_HK { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "Nvarchar")]
        [Display(Name = "English", Order = 4)]
        public string en_US { get; set; }
    }
}
