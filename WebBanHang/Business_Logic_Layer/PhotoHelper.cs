using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WebBanHang.Business_Logic_Layer
{
    public class PhotoHelper
    {
        public static string _DEFAULT_FILE_NAME = "default.jpg";
        public static string SaveToServer(HttpPostedFileBase photo)
        {
            string[] photoName = photo.FileName.Split('.');
            string fileName = Guid.NewGuid().ToString();
            string fileType = photoName[1];

            string fileNameFinal = fileName + "." + fileType;
            string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/"), fileNameFinal);
            photo.SaveAs(path);

            return fileNameFinal;
        }
    }
}