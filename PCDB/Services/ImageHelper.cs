using PCDB.Models.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCDB.Services
{
    public static class ImageHelper
    {
        public static string UploadComponentImage(Component component, HttpPostedFileBase image)
        {
            var filename = image != null ? image.FileName : "";
            var imageId = Guid.NewGuid().ToString();
            var directory = "";
            var defaultImagePath = "";

            if (component is CPU)
            {
                directory = "CPU";
                defaultImagePath = "Content/Images/cpu.png";
            }
            else if  (component is CPUCooler)
            {
                directory = "CPUCooler";
                defaultImagePath = "Content/Images/fan.png";
            }
            else if (component is Case)
            {
                directory = "Case";
                //defaultImagePath = "Content/Images/case.png";
            }
            else if (component is Memory)
            {
                directory = "Memory";
                defaultImagePath = "Content/Images/ram-memory.png";
            }
            else if (component is Motherboard)
            {
                directory = "Motherboard";
                defaultImagePath = "Content/Images/motherboard.png";
            }
            else if (component is PowerSupply)
            {
                directory = "PowerSuply";
                defaultImagePath = "Content/Images/power.png";
            }
            else if (component is Storage)
            {
                directory = "Storage";
                defaultImagePath = "Content/Images/harddisk.png";
            }
            else if (component is VideoCard)
            {
                directory = "VideoCard";
                defaultImagePath = "Content/Images/video-card.png";
            }

            if (DirectoryExists(directory))
            {
                if (image != null)
                {
                    var extension = Path.GetExtension(filename);
                    var filePath = Path.Combine(GetFullPath(directory), $"{imageId}{extension}");
                    image.SaveAs(filePath);
                    //return Path.Combine(directory, $"{imageId}{extension}");
                    return Path.Combine("Uploads", "Images", directory, $"{imageId}{extension}");
                }
                else
                {
                    return defaultImagePath;
                }
            }

            return String.Empty;
        }

        public static string GetComponentImage(string componentImagePath)
        {
            var path = AppContext.BaseDirectory;
            return Path.Combine(path, componentImagePath);
        }

        public static void RemoveImage(string componentImagePath)
        {
            if (!String.IsNullOrEmpty(componentImagePath) && !componentImagePath.Contains("Content/Images"))
            {
                var path = Path.Combine(AppContext.BaseDirectory, componentImagePath);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        private static string GetFullPath(string directory)
        {
            var path = AppContext.BaseDirectory;
            var uploadDirectory = "Uploads/Images/";
            return Path.Combine(path, uploadDirectory, directory);
        }

        private static bool DirectoryExists(string directory)
        {
            return Directory.Exists(GetFullPath(directory));
        }
    }
}