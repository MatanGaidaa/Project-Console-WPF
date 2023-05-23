using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace Exe3_OrelOssi_LinEini
{
    public class DataFile
    {
        internal string FileName;
        internal DateTime lastUpdateTime = new DateTime();
        internal string Data;
        internal FileTypeExtension type;
        internal static int counter;
        public DataFile() : this("sameFile" + ++counter, "  ", FileTypeExtension.TXT)
        {
        }
        public string getData()
        {
            return Data;
        }
        public FileTypeExtension getType()
        {
            return type;
        }
        public void setType(FileTypeExtension type)
        {
            this.type = type;
        }
        public void setData(string Data)
        {
            this.Data = Data;
        }
        public string getFileName()
        {
            return FileName;
        }
        public void setFileName(string FileName)
        {
            if (FileName == null)
                FileName = null;
            while (FileName.Contains("<") || FileName.Contains("?") ||
            FileName.Contains("*") || FileName.Contains(":") ||
           FileName.Contains("/")
            || FileName.Contains("\\") || FileName.Contains("|") ||
            FileName.Contains(">"))
            {
                Console.WriteLine("A file name can't contain any of the  following characters: \\ / : * < > | ");



                Console.WriteLine("Please Write File name again: ");
                FileName = Console.ReadLine();
            }
            this.FileName = FileName;
        }
        public void SetTime()
        {
            lastUpdateTime = DateTime.Now;
        }
        public DateTime GetTime()
        {
            return lastUpdateTime;
        }
        public DataFile(string FileName, string Data, FileTypeExtension type)
        {
            setFileName(FileName);
            lastUpdateTime = DateTime.Now;
            this.Data = Data;
            this.type = type;
        }
        public DataFile(DataFile other)
        {
            FileName = other.FileName + " Copy";
            lastUpdateTime = other.lastUpdateTime;
            Data = other.Data;
            type = other.type;
        }
        public double GetSize()
        {
            if (Data == null) return 0;
            return (Data.Length);
        }
        public DataFile Dir(DataFile other)
        {
            double sizeOfData = GetSize() / 1024;
            other.setFileName(other.FileName);
            other.setData(other.Data);
            return other;
        }
    }
}
