﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrustructure;
using System.Data.Entity;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using System.IO.IsolatedStorage;
using System.Security.Permissions;
using System.Security.AccessControl;


namespace LeduInfo.Models
{
    [FileIOPermission(SecurityAction.Demand, AllLocalFiles=FileIOPermissionAccess.AllAccess)]
    public class FileModel
    {

        #region initial instant of Data
        public int FileID { get; set; }
        public string FileName { get; set; }
        public string LastModified { get; set; }
        public List<string> FilePaths { get; set; }
        Image img = new Image();
        leduInfoDB DB = new leduInfoDB();
        #endregion

        //public FileModel()
        //{
        //    FileIOPermission f = new FileIOPermission(FileIOPermissionAccess.Write, ConfigurationManager.AppSettings["ImgBasePath"].ToString());
        //    f.AddPathList(FileIOPermissionAccess.AllAccess, "C:\\CodeForFun\\InforwebMvc4\\LeduInfo\\Images\\ImgFolder");
        //    f.Demand();
        //    if (Directory.GetDirectories(ConfigurationManager.AppSettings["ImgBasePath"]).Length > 0 || Directory.GetFiles(ConfigurationManager.AppSettings["ImgBasePath"]).Length > 0)
        //    {
               
        //        FileInfo fi = new FileInfo(ConfigurationManager.AppSettings["ImgBasePath"].ToString());
        //        FileSecurity fs=fi.GetAccessControl();
        //        fs.AddAccessRule(new FileSystemAccessRule(Environment.UserName,FileSystemRights.FullControl,AccessControlType.Allow));
                
        //        fi.CopyTo("~/Images/ImgFolder", true);
        //        FileSecurity FS = new FileSecurity();

        //        fi.SetAccessControl(FS);
                
        //    }
            
        //}
        public void SaveFilePath()
        {
           var paths = img.GetFilePaths(ConfigurationManager.AppSettings["ImgBasePath"].ToString());
            
           foreach (var item in paths)
           {
               var image = from images in DB.FileResourcetbl
                           where images.Path==item 
                           select images;

               if (!image.Any())
               {
                   DB.FileResourcetbl.Add(new FileResource { Path= item, FileTypeID= 1 });
                   DB.FileTypetbl.Add(new FileType { fileType = "image" });
               }
              
           } 
            DB.SaveChanges();
        }

        public void SaveFileAsRelativePath()
        {
            
        }
                
    }
}