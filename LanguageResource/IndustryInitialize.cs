using LanguageResource.Modal;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations;

namespace LanguageResource
{
    public static class IndustryInitialize
    {
        private static Model1 context = new Model1(); 
        public static void IndustryInitializeSeedData()
        {
            #region  Initialize seed data
     //       var Industries = new List<Industry>
     //       {
				 //new Industry{ IndustryId ="IN00001" , IndustryName ="商用服務業", En_IndustryName ="Commercial service industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00002" , IndustryName ="飲食業", En_IndustryName ="Catering industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00003" , IndustryName ="通訊業", En_IndustryName ="Communication industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00004" , IndustryName ="建造業", En_IndustryName ="Construction industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00005" , IndustryName ="住戶服務業", En_IndustryName ="Household service industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00006" , IndustryName ="教育服務業", En_IndustryName ="Educational service industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00007" , IndustryName ="金融業", En_IndustryName ="Financial industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00008" , IndustryName ="政府部門", En_IndustryName ="Government department",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00009" , IndustryName ="醫院", En_IndustryName ="hospital",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00010" , IndustryName ="酒店業", En_IndustryName ="Hotel industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00011" , IndustryName ="進出口貿易", En_IndustryName ="import and export trade",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00012" , IndustryName ="保險業", En_IndustryName ="Insurance",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00013" , IndustryName ="電子製品業", En_IndustryName ="Electronic products industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00014" , IndustryName ="金屬製品業", En_IndustryName ="Metal products industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00015" , IndustryName ="塑膠製品業", En_IndustryName ="Plastic products industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00016" , IndustryName ="紡織業", En_IndustryName ="Textile industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00017" , IndustryName ="服裝製品業", En_IndustryName ="Clothing industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00018" , IndustryName ="地產業", En_IndustryName ="Real estate industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00019" , IndustryName ="零售業", En_IndustryName ="Retail industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00020" , IndustryName ="倉庫業", En_IndustryName ="Warehouse industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00021" , IndustryName ="運輸業", En_IndustryName ="Transportation industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00022" , IndustryName ="福利機構", En_IndustryName ="Welfare institution",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00023" , IndustryName ="批發業", En_IndustryName ="Wholesale industry",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00024" , IndustryName ="其他社區及社會服務業", En_IndustryName ="Other community and social services",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00025" , IndustryName ="其他製造業", En_IndustryName ="Other manufacturing",ParentsIndustryId=0},
				 //new Industry{ IndustryId ="IN00026" , IndustryName ="其他個人服務業", En_IndustryName ="Other personal services",ParentsIndustryId=0}, 
     //       };
     //       Industries.ForEach(a => context.Industries.AddOrUpdate(a)); //Industries
     //       context.SaveChanges();
            #endregion
        }
    }

    public class Industry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        [MaxLength(20)]
        [Column(TypeName = "Nvarchar")]
        public string IndustryId { get; set; }

        [Required] 
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string IndustryName { get; set; }
         
        [MaxLength(50)]
        [Column(TypeName = "Nvarchar")]
        public string En_IndustryName { get; set; }

        [Required] 
        [DefaultValue(0)]
        public int ParentsIndustryId { get; set; }
    }
}