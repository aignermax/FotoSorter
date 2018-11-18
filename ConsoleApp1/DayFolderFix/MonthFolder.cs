using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DayFolderFix
{
    public class MonthFolder
    {
        public List<DayFolder> myDayFolders = new List<DayFolder>();
        public YearFolder myYearFolder;
        public string Month;
        public MonthFolder(YearFolder myYearFolder, string Month)
        {

        }
    }
}
