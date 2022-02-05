using DataGuard.Context;
using LanguageResource;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataGuard.Models.PubDataModel
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [LocalizedDisplayName("Job Id", KeyName = "Job_JobId", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "Nvarchar")]
        public string JobId { get; set; }

        [LocalizedDisplayName("The 3rd JobId", KeyName = "Job_The3rdJobId", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "Nvarchar")]
        public string The3rdJobId { get; set; }

        [LocalizedDisplayName("Job Name", KeyName = "Job_JobName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string JobName { get; set; }

        [LocalizedDisplayName("Job Eng Name", KeyName = "Job_EnJobName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string EnJobName { get; set; }

        [LocalizedDisplayName("Industry Id", KeyName = "Job_IndustryId", KeyType = KeyType.Modal)]
        [MaxLength(20)]
        [Column(TypeName = "Nvarchar")]
        public string IndustryId { get; set; }

        [Required]
        [LocalizedDisplayName("Industry Name", KeyName = "Job_IndustryName", KeyType = KeyType.Modal)]
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string IndustryName { get; set; }
    }
}