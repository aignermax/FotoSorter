using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class FotoList
    {
        public List<Foto> Fotos;

        public FotoList(string[] myFotosFileNames)
        {
            Fotos = new List<Foto>();
            foreach(string filename in myFotosFileNames)
            {
                Fotos.Add(new Foto(filename));
            }
        }
        
        public void CreateFoldersOfImageDates()
        {
            foreach(Foto f in this.Fotos)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(f.ImgPath) + "\\"+ f.GetImageDateString());
            }
        }

        public void MoveImages()
        {
            CreateFoldersOfImageDates();
            // move images to day folders
            foreach (Foto f in this.Fotos)
            {
                File.Move(f.ImgPath, Path.GetDirectoryName(f.ImgPath) + "\\" + f.GetImageDateString() + "\\" + Path.GetFileName(f.ImgPath));
            }
        }
    }
}
