using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DayFolderFix
{
    public class DayFolder
    {
        public List<Foto> myFotos = new List<Foto>();
        public string Day;
        public MonthFolder myMonthFolder;

        public DayFolder(MonthFolder myMonthFolder,  string Day)
        {
            this.Day = Day;
            this.myMonthFolder = myMonthFolder;
        }

        public int GetFolderFotoCount()
        {
            return myFotos.Count;
        }
        public void MoveFotosUp()
        {
            foreach (Foto f in myFotos)
            {
                File.Move(f.ImgPath, Path.GetDirectoryName(f.ImgPath) + "\\" + f.GetImageDateString() + "\\" + Path.GetFileName(f.ImgPath));
            }
        }
    }
}
