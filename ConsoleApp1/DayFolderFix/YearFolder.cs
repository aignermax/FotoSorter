using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.DayFolderFix
{
    public class YearFolder
    {
        // for example 2018
        public string Year;
        public ImageFolder myImageFolder;
        public List<MonthFolder> myMonthFolders = new List<MonthFolder>();

        public YearFolder( ImageFolder imageFolder, string Year)
        {
            this.myImageFolder = imageFolder;
        }

        public void LoadMonths()
        {
            // check for folders that have the same YEAR as start and a month on it and length of 7
            // 2018-01
            string[] Months = Directory.GetDirectories(Path.Combine(myImageFolder.ImageFolderPath,this.Year));
            foreach(string m in Months)
            {
                CreateNewMonth(m);
            }
        }

        //public bool IsValidMonth(string MonthFolderName)
        //{
        //    //FolderName is YYYY-MM
        //    //var r = new Regex("^\\d(\\d|(?<!-)-)*\\d$|^\\d$");
        //    //Console.WriteLine(r.IsMatch("1-2-3"));
            
        //}
        // Return MM from YYYY-MM
        //private string ExtractMonthFromMonthFolderName()
        //{

        //}
        public void CreateNewMonth(string MonthFolderName)
        {
            //if(IsValidMonth(MonthFolderName))
            //{
            //    myMonthFolders.Add(new MonthFolder(this, Month));
            //}
        }
        
    }
}
