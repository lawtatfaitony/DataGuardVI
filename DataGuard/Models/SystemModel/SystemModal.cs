namespace DataGuard.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TableIdentity
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "nvarchar")]
        public string TableName { get; set; }

        [Column(TypeName = "int")]
        public int TableIdentityID { get; set; } //Each time you add it, you will automatically add 1 and add 1 to each new call, regardless of whether the new one is successful or not.

        [Column(TypeName = "datetime")]
        [DefaultValue(typeof(DateTime), "")]
        public DateTime OperatedDate { get; set; }
    }

}