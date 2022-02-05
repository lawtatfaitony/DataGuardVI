using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing; 

namespace AttendanceBussiness
{
    public class Utility
    {
        public static bool SaveImage(string Path1, string FileName, string PhotoBase64)
        {
            string PathFileName = Path.Combine(Path1, FileName);
            byte[] bt = Convert.FromBase64String(PhotoBase64);

            if (System.IO.Directory.Exists(Path1) == false)
            {
                System.IO.Directory.CreateDirectory(Path1);
            }
            try
            {
                File.WriteAllBytes(PathFileName, bt);
            }
            catch
            {
                return false;
            }
            return true;
        }
    } 
}