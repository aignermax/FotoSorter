using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            string FotoDir = @"C:\Users\max_a\Dropbox\Kamera-Uploads"; // args[0];
            Console.WriteLine("Start Sorting Fotos at: " + FotoDir);
            // Scan Folder to get all files and put them into a list 
            string[] Images = Directory.GetFiles(FotoDir);
            FotoList myFotoList = new FotoList(Images);

            // create Day Folders and insert images of that day into them (get date by IMG Name. if not possible - use changedate)
            Console.WriteLine("Start Moving Fotos" );
            myFotoList.MoveImages();
            Console.WriteLine("Moved Fotos");
            // Create Month Folders and move all DayFolders into those
            SortDayFoldersToMonths(FotoDir);
            // create Year Folders and sort all Month folders into those.
            SortMonthsIntoYears(FotoDir);
            Console.ReadLine();
        }


        public static void SortDayFoldersToMonths(string FotoDir)
        {
            
            // scan all foldernames
            Console.WriteLine("Move Directories to Month Directories");
            string[] subdirectoryEntries = Directory.GetDirectories(FotoDir);
            foreach (string s in subdirectoryEntries)
            {
                string FolderName = new DirectoryInfo(s).Name;
                try
                {
                    string folderdate = FolderName.Substring(0, 10);
                    string monthFolderName = Directory.GetParent(s).FullName + "\\" + folderdate.Substring(0, 7);
                    DateTime dirDateTime = DateTime.ParseExact(folderdate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    Directory.CreateDirectory(monthFolderName);
                    MoveAll(new DirectoryInfo(s), new DirectoryInfo(monthFolderName + "\\" + FolderName));
                    // delete the now empty directory
                    if (IsFolderEmpty(s))
                    {
                        Directory.Delete(s, false);
                    }
                    
                    Console.WriteLine("Moved Dir " + FolderName + " Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + s);
                }

            }

        }

        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }
        public static bool IsFolderEmpty(string path)
        {
            return DirSize(new DirectoryInfo(path)) == 0 ? true : false ;
        }

        public static void SortMonthsIntoYears(string FotoDir)
        {
            // scan all foldernames
            Console.WriteLine("Move Month Directories to Year Directories");
            string[] subdirectoryEntries = Directory.GetDirectories(FotoDir);
            foreach (string s in subdirectoryEntries)
            {
                string FolderName = new DirectoryInfo(s).Name;
                try
                {
                    string folderdate = FolderName.Substring(0, 7); 
                    string YearFolderName = Directory.GetParent(s).FullName + "\\" + folderdate.Substring(0, 4);
                    DateTime dirDateTime = DateTime.ParseExact(folderdate, "yyyy-MM", System.Globalization.CultureInfo.InvariantCulture);
                    Directory.CreateDirectory(YearFolderName);
                    
                    MoveAll(new DirectoryInfo(s), new DirectoryInfo(YearFolderName + "\\" + FolderName));
                    // delete the now empty directory
                    if (IsFolderEmpty(s))
                    {
                        Directory.Delete(s, true);
                    }
                    
                    Console.WriteLine("Moved Dir " + FolderName + " Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + s);
                }

            }
        }

        public static void MoveAll(DirectoryInfo source, DirectoryInfo target)
        {
            if (source.FullName.ToLower() == target.FullName.ToLower())
            {
                return;
            }

            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into it's new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.MoveTo(Path.Combine(target.ToString(), fi.Name));
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                MoveAll(diSourceSubDir, nextTargetSubDir);
            }
        }

    }
}
