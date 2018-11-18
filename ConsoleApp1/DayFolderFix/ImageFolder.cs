using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DayFolderFix
{
    public class ImageFolder
    {
        public List<YearFolder> myYearFolders;
        public string ImageFolderPath;

        public ImageFolder(string imageFolderPath)
        {
            this.ImageFolderPath = imageFolderPath;
            myYearFolders = new List<YearFolder>();
        }

        public void CheckDayFolders(string ImageFolderPath)
        {
            // Create MonthFolders
            string[] directories = Directory.GetDirectories(ImageFolderPath);
            foreach (string d in directories)
            {
                // find all years (4-Digit folders)
                string Year = Path.GetDirectoryName(d);
                if (Year.Length == 4)
                {
                    try
                    {
                        Convert.ToInt32(Year);
                        YearFolder newYear = new YearFolder(this ,Year);

                    }
                    catch{

                    }

                }
            }
        }
    }
}
