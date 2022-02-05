using AttendanceBussiness.DbFirst;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;

namespace DataGuard.Utilities
{
    public class AdditionalForUpload
    {
        public static bool AlterTempTargetTalbeKeyID(DataBaseContext dbContext, string TempID, string TargetTalbeKeyID)
        {
            try
            {
                if (dbContext.UploadItem.Where(c => c.TargetTalbeKeyId == TempID).ToList().Count > 0)
                {
                    var uploadItems = dbContext.UploadItem.Where(c => c.TargetTalbeKeyId == TempID).ToList();
                    foreach (var item in uploadItems)
                    {
                        item.TargetTalbeKeyId = TargetTalbeKeyID;
                    }
                    dbContext.UploadItem.UpdateRange(uploadItems);
                    bool result = dbContext.SaveChanges() > 0 ? true : false;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #region GetPicThumbnail  
        /// <summary>
        /// GetPicThumbnail For .NET FRAMEWORK
        /// </summary>
        /// <param name="sFile"></param>
        /// <param name="dFile"></param>
        /// <param name="dHeight"></param>
        /// <param name="dWidth"></param>
        /// <param name="flag">40 to 100</param>
        /// <returns></returns>
        public static bool GetPicThumbnail(string sFile, string dFile, int dHeight, int dWidth, int flag)
        {
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            int sW = 0, sH = 0;
            Bitmap ob;
            //按比例缩放 
            Size tem_size = new Size(iSource.Width, iSource.Height);
            if (tem_size.Width > dHeight || tem_size.Height > dWidth) //将**改成c#中的或者操作符号
            {
                if ((tem_size.Width * dHeight) > (tem_size.Height * dWidth))
                {
                    sW = dWidth;
                    sH = (dWidth * tem_size.Height) / tem_size.Width;
                    ob = new Bitmap(sW, sH);
                }
                else
                {
                    sH = dHeight;
                    sW = (dHeight * tem_size.Width) / tem_size.Height;
                    ob = new Bitmap(sW, sH);
                }
            }
            else
            {
                sW = tem_size.Width;
                sH = tem_size.Height;
                ob = new Bitmap(sW, sH);
            }

            Graphics g = Graphics.FromImage(ob);
            g.Clear(Color.White); //g.Clear(Color.Transparent); 透明
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(iSource, new Rectangle(0, 0, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);
            g.Dispose();
            //以下代码为保存图片时，设置压缩质量 
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100 
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径 
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                iSource.Dispose();
                ob.Dispose();

            }
        }
        #endregion
        public static ImageRetangleSize GetImageRetangleSize(string sFile)
        {
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            Size tem_size = new Size(iSource.Width, iSource.Height);
            ImageRetangleSize imageRetangleSize = new ImageRetangleSize { Width = tem_size.Width, Height = tem_size.Height };
            iSource.Dispose();
            return imageRetangleSize;
        }
        public class ImageRetangleSize
        {
            public int Width;
            public int Height;
        }
    }
}