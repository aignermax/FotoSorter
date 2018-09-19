using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Foto
    {
        public string ImgPath;
        public DateTime FotoDate;

        public Foto(string imgPath )
        {
            this.ImgPath = imgPath;
            InitImageDate();
        }
        
        /// <summary>
        /// returns a YYYY-MM-DD String of the image date
        /// </summary>
        /// <returns></returns>
        private void InitImageDate()
        {
            try
            {
                DateTime PathTime = DateTime.ParseExact(Path.GetFileNameWithoutExtension(this.ImgPath), "yyyy-MM-dd HH.mm.ss", System.Globalization.CultureInfo.InvariantCulture);
                this.FotoDate = PathTime;
            } catch
            {
                this.FotoDate = File.GetLastWriteTime(this.ImgPath);
            }
        }

        public string GetImageDateString()
        {
            return this.FotoDate.ToString("yyyy-MM-dd");
        }
    }
}
