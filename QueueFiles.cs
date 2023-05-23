using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Exe3_OrelOssi_LinEini
{
    public class QueueFiles
    {
        DataFile[] arr;
        uint index;
        public QueueFiles()
        {
            arr = new DataFile[1];
            index = 0;
        }
        public QueueFiles(QueueFiles queue)
        {
            arr = new DataFile[queue.arr.Length];
            queue.arr.CopyTo(arr, 0);
            index = queue.Length;
        }
        public bool IsEmpty()
        {
            return index == 0;
        }
        public uint Length => index;
        public void Enqueue(DataFile other)
        {
            for (int i = 0; i < index; i++)
            {
                if (CompareFiles.EqualFiles(arr[i], other))
                {
                    Console.WriteLine("The File already exist");
                    return;
                }
            }
            arr[index++] = other;
            Array.Resize(ref arr, arr.Length + 1);
        }
        public DataFile Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("The queue is empty therfore you can't delete");
                return null;
            }
            DataFile other = arr[0];
            for (int i = 0; i < index - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            index--;
            arr[index] = null;
            return other;
        }
        public DataFile BigFile()
        {
            if (index == 1)
            {
                Console.WriteLine("The has 1 DataFile");
                return arr[0];
            }
            DataFile file;
            DataFile tempbig;
            QueueFiles copy = new QueueFiles(this);
            file = copy.Dequeue();
            tempbig = file;
            while (!copy.IsEmpty())
            {
                file = copy.Dequeue();
                if (CompareFiles.CompareSizeFiles(file, tempbig) == 1)
                    tempbig = file;
            }
            DataFile.counter--;
            return tempbig;
        }
        public List<DataFile> PrintQueue()
        {
            var listDataFile = new List<DataFile>();
            if (IsEmpty())
            {
                listDataFile = null;
            }
            DataFile file;
            QueueFiles copy = new QueueFiles(this);
            while (!copy.IsEmpty())
            {
                file = copy.Dequeue();
                file.Dir(file);
                listDataFile.Add(file);
            }
            return listDataFile;
        }
        public DataFile[] SearchFileByType(FileTypeExtension type)
        {
            DataFile[] temp = new DataFile[arr.Length];
            QueueFiles copy = new QueueFiles(this);
            DataFile file;
            int j = 0;

            while (!copy.IsEmpty())
            {
                file = copy.Dequeue();
                if (file.getType() == type)
                {
                    temp[j++] = file;
                }
            }
            Array.Resize(ref temp, j);
            return temp;
        }
    }
}
