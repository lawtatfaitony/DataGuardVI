using AttendanceBussiness.DbFirst;
using Common;
using DataGuard.Utilities;
using System;
using System.Web;
using System.Web.Mvc;

namespace DataGuard.Controllers
{
    [Authorize]
    public class UtilitiesController : Controller
    {
        private DataBaseContext dbContext = new DataBaseContext();
        static string urlPath = string.Empty;
        public UtilitiesController()
        {
            var applicationPath = VirtualPathUtility.ToAbsolute("~") == "/" ? "" : VirtualPathUtility.ToAbsolute("~");
            urlPath = applicationPath + "/Upload";

        }

        [Authorize]
        [HttpPost]
        public ActionResult UpLoadProcessX(string Prefix, string SubPath, string TargetTalbeKeyId, string MainComId, HttpPostedFileBase file)
        {
            string oSubPath = SubPath.ToLower();
            string filePathName = string.Empty;
            //文件名称前缀
            if (!string.IsNullOrEmpty(Prefix))
            {
                if (Prefix.Length >= 1)
                {
                    filePathName = Prefix + filePathName;
                }
            }
            string localPath = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "Upload");
            //指定 至文件夹
            if (SubPath.Length > 1)
            {
                localPath = System.IO.Path.Combine(localPath, SubPath);
                urlPath += "/" + SubPath;
            }

            if (Request.Files.Count == 0)
            {
                return Json(new
                {
                    UploadItemId = "0"
                    ,
                    filePathName = ""
                });
            }
            string ex = System.IO.Path.GetExtension(file.FileName);

            filePathName += DateTime.Now.ToString("yyyyMMddHHmmssfff") + ex;

            if (!System.IO.Directory.Exists(localPath))
            {
                System.IO.Directory.CreateDirectory(localPath);
            }
            file.SaveAs(System.IO.Path.Combine(localPath, filePathName));

            #region //图片压缩
            //如果是产品主图 则生成不同规格的缩略图  PictureSize = IsNotPict= 0 ,s60x60= 1, s100X100 = 2,s160X160= 3 ,s250X250 = 4, s300X300 = 5, s350X350 = 6, s600X600 = 7

            bool thumbnail_ok = false;
            string sFile = System.IO.Path.Combine(localPath, filePathName);
            string dFile = System.IO.Path.Combine(localPath, filePathName);
            string dThumbnailFile;
            int flag = 100;
            AdditionalForUpload.ImageRetangleSize imageRetangleSize = AdditionalForUpload.GetImageRetangleSize(sFile);
            string ReturnReult;
            switch (oSubPath)
            {
                case "employee":
                    try
                    {
                        if (imageRetangleSize.Width > 60 || imageRetangleSize.Height > 60)
                        {
                            dThumbnailFile = dFile + Common.PictureSize.s60X60.ToString() + ex;
                            thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 60, 60, flag);
                        }
                        if (imageRetangleSize.Width > 100 || imageRetangleSize.Height > 100)
                        {
                            dThumbnailFile = dFile + PictureSize.s100X100.ToString() + ex;
                            thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 100, 100, flag);
                        }
                        if (imageRetangleSize.Width > 160 || imageRetangleSize.Height > 160)
                        {
                            dThumbnailFile = dFile + PictureSize.s60X60.ToString() + ex;
                            thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 160, 160, flag);
                        }
                        if (imageRetangleSize.Width > 250 || imageRetangleSize.Height > 250)
                        {
                            dThumbnailFile = dFile + PictureSize.s250X250.ToString() + ex;
                            thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 250, 250, flag);
                        }
                        if (imageRetangleSize.Width > 310 || imageRetangleSize.Height > 310)
                        {
                            dThumbnailFile = dFile + PictureSize.s310X310.ToString() + ex;
                            thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 310, 310, flag);
                        }
                        if (imageRetangleSize.Width > 350 || imageRetangleSize.Height > 350)
                        {
                            dThumbnailFile = dFile + PictureSize.s350X350.ToString() + ex;
                            thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, imageRetangleSize.Height, imageRetangleSize.Width, flag);
                        }
                        if (imageRetangleSize.Width > 1000 || imageRetangleSize.Height > 1000)
                        {
                            dThumbnailFile = dFile + PictureSize.s600X600.ToString() + ex;  //for AccuId images required
                            thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 1000, 1000, flag); //for AccuId images required
                        }
                    }
                    catch
                    {
                        break;
                    }

                    break;

                case "info":

                    if (imageRetangleSize.Width > 160 || imageRetangleSize.Height > 160)
                    {
                        dThumbnailFile = dFile + PictureSize.s160X160.ToString() + ex;
                        thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 160, 160, flag);
                    }
                    if (imageRetangleSize.Width > 250 || imageRetangleSize.Height > 250)
                    {
                        dThumbnailFile = dFile + PictureSize.s250X250.ToString() + ex;
                        thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 250, 250, flag);
                    }
                    if (imageRetangleSize.Width > 310 || imageRetangleSize.Height > 310)
                    {
                        dThumbnailFile = dFile + PictureSize.s310X310.ToString() + ex;
                        thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 310, 310, flag);
                    }
                    if (imageRetangleSize.Width > 350 || imageRetangleSize.Height > 350)
                    {
                        dThumbnailFile = dFile + PictureSize.s350X350.ToString() + ex;
                        thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 350, 350, flag);
                    }
                    if (imageRetangleSize.Width > 600 || imageRetangleSize.Height > 600)
                    {
                        dThumbnailFile = dFile + PictureSize.s600X600.ToString() + ex;
                        thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 600, 600, flag);
                    }
                    break;
                case "contractor":
                    if (imageRetangleSize.Width > 60 || imageRetangleSize.Height > 60)
                    {
                        dThumbnailFile = dFile + PictureSize.s60X60.ToString() + ex;
                        thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 60, 60, flag);
                    }

                    if (imageRetangleSize.Width > 100 || imageRetangleSize.Height > 100)
                    {
                        dThumbnailFile = dFile + PictureSize.s100X100.ToString() + ex;
                        thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 100, 100, flag);
                    }
                    if (imageRetangleSize.Width > 160 || imageRetangleSize.Height > 160)
                    {
                        dThumbnailFile = dFile + PictureSize.s160X160.ToString() + ex;
                        thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 160, 160, flag);
                    }
                    if (imageRetangleSize.Width > 250 || imageRetangleSize.Height > 250)
                    {
                        dThumbnailFile = dFile + PictureSize.s250X250.ToString() + ex;
                        thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 250, 250, flag);
                    }
                    if (imageRetangleSize.Width > 310 || imageRetangleSize.Height > 310)
                    {
                        dThumbnailFile = dFile + PictureSize.s310X310.ToString() + ex;
                        thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 310, 310, flag);
                    }
                    if (imageRetangleSize.Width > 350 || imageRetangleSize.Height > 350)
                    {
                        dThumbnailFile = dFile + PictureSize.s350X350.ToString() + ex;
                        thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 350, 350, flag);
                    }
                    if (imageRetangleSize.Width > 600 || imageRetangleSize.Height > 600)
                    {
                        dThumbnailFile = dFile + PictureSize.s600X600.ToString() + ex;
                        thumbnail_ok = AdditionalForUpload.GetPicThumbnail(sFile, dThumbnailFile, 600, 600, flag);
                    }
                    break;
            }

            #endregion

            //数据记录
            UploadItem uploadItem = new UploadItem();
            string UploadItemId = dbContext.GetTableIdentityID("UP", "UploadItem", 20);
            uploadItem.UploadItemId = UploadItemId;
            uploadItem.TargetTalbeKeyId = TargetTalbeKeyId;
            uploadItem.RankOrder = 0;   // 0: 表示 不排序
            uploadItem.RawName = file.FileName;
            uploadItem.MainComId = MainComId;
            uploadItem.SubPath = SubPath;
            uploadItem.Url = urlPath + "/" + filePathName;
            uploadItem.FileExt = ex;
            uploadItem.OperatedUserName = User.Identity.Name;
            uploadItem.OperatedDate = DateTime.Now;

            dbContext.UploadItem.Add(uploadItem);
            dbContext.SaveChanges();

            ReturnReult = urlPath + "/" + filePathName;

            if (oSubPath.ToLower() == "employee" || oSubPath.ToLower() == "maincom")
            {
                return Json(new
                {
                    UploadItemId = UploadItemId.Trim(),
                    filePathName = ReturnReult
                });
            }
            return Content(ReturnReult);
        }


    }


}