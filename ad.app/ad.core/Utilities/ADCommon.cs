using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ad.Core
{
    public static class ADCommon
    {

        #region
        public static string[] SplitPath(string sourceDir, string[] sp = null)
        {
            string sp1 = "AD";
            if (sp == null)
            {
                sp = new string[] { sp1 };
            }
            return sourceDir.Split(sp, StringSplitOptions.None);
        }
        public static bool MoveFile(string sourceFile, string destinationFile)
        {
            try
            {
                if (!File.Exists(sourceFile))
                {
                    // This statement ensures that the file is created,  
                    // but the handle is not kept.  
                    using (FileStream fs = File.Create(sourceFile)) { }
                }
                // Ensure that the target does not exist.  
                if (File.Exists(destinationFile))
                    File.Delete(destinationFile);
                // Move the file.  
                File.Move(sourceFile, destinationFile);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool CopyFolder(string sourceDir, string destDir)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(sourceDir);
                DirectoryInfo[] dirs = dir.GetDirectories();
                if (!dir.Exists)
                {
                    return false;
                }
                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                }
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDir, file.Name);
                    file.CopyTo(temppath, true);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region  duyet cay
        public static void FilterFolder(string pathFolder = null, string drive = null)
        {

            // Start with drives if you have to search the entire computer.
            var drives = System.Environment.GetLogicalDrives().ToList();
            var drives1 = drives.Where(x => x.Contains(drive)).ToList();
            drives = drive!=null ? drives1.ToList() : drives.ToList();
            foreach (string dr in drives)
            {
                System.IO.DriveInfo di = new System.IO.DriveInfo(dr);

                // Here we skip the drive if it is not ready to be read. This
                // is not necessarily the appropriate action in all scenarios.
                if (!di.IsReady)
                {
                    Console.WriteLine("The drive {0} could not be read", di.Name);
                    continue;
                }
                System.IO.DirectoryInfo rootDir = di.RootDirectory;
                List<Paths> paths = new List<Paths>();
                WalkDirectoryTree(rootDir, pathFolder);
            }

        }
        public static void WalkDirectoryTree(System.IO.DirectoryInfo root, string pathFolder)
        {

            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;
            files = root.GetFiles("*.*");
            // First, process all the files directly under this folder


            try
            {
                if (files != null)
                {
                    //foreach (System.IO.FileInfo fi in files)
                    //{
                    //    // In this example, we only access the existing FileInfo object. If we
                    //    // want to open, delete or modify the file, then
                    //    // a try-catch block is required here to handle the case
                    //    // where the file has been deleted since the call to TraverseTree().
                    //    Console.WriteLine(fi.FullName);
                    //}

                    // Now find all the subdirectories under this directory.
                    subDirs = root.GetDirectories();

                    foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                    {
                        // Resursive call for each subdirectory'=.
                        var g = new Paths()
                        {
                            Name= dirInfo.Name,
                            PathFiles=subDirs.Select(x => x.FullName).ToList()
                        };
                        WalkDirectoryTree(dirInfo, pathFolder);
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }

        }
        #endregion
    }
    public class Paths
    {
        public string Name { get; set; }
        public List<string> PathFiles { get; set; }
    }

}
