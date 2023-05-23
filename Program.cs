using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Exe3_OrelOssi_LinEini;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
namespace Exe3_OrelOssi_LinEini
{
    public enum FileTypeExtension
    {
        TXT = 1, DOC = 2, DOCX = 3, PDF = 4, PPTX = 5
    };
    internal class Program
    {
        static FileTypeExtension getTypeByNum(int num)
        {
            FileTypeExtension type;
            switch (num)
            {
                case 1:
                    type = FileTypeExtension.TXT;
                    break;
                case 2:
                    type = FileTypeExtension.DOC;
                    break;
                case 3:
                    type = FileTypeExtension.DOCX;
                    break;
                case 4:
                    type = FileTypeExtension.PDF;
                    break;
                case 5:
                    type = FileTypeExtension.PPTX;
                    break;
                default:
                    type = FileTypeExtension.TXT;
                    break;
            }
            return type;
        }
        static void Main(string[] args)
        {
            int a;
            QueueFiles d = new QueueFiles();
            do
            {
                Console.WriteLine("Choose one the options below:");
                Console.WriteLine();
                Console.WriteLine(" i. Add a DEFAULT File");
                Console.WriteLine("-----------------------");
                Console.WriteLine(" ii. Add a STRUCT File");
                Console.WriteLine("-----------------------");
                Console.WriteLine("iii. Out File on FIFO");
                Console.WriteLine("-----------------------");
                Console.WriteLine(" iv. Print all files");
                Console.WriteLine("-----------------------");
                Console.WriteLine(" v. Search files by type");
                Console.WriteLine("-----------------------");
                Console.WriteLine(" vi. Print biggest file");
                Console.WriteLine("-----------------------");
                Console.WriteLine("vii. End program");
                Console.Write("Enter: ");
                a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        DataFile d1 = new DataFile();
                        d.Enqueue(d1);
                        break;
                    case 2:
                        Console.WriteLine("Enter Name:");
                        string fileName = Console.ReadLine();
                        Console.WriteLine("Enter Data:");
                        string fileData = Console.ReadLine();
                        Console.WriteLine("Enter Type: ");
                        FileTypeExtension filetype = getTypeByNum(int.Parse(Console.ReadLine()));
                        d.Enqueue(new DataFile(fileName, fileData, filetype));
                        break;
                    case 3:
                        d.Dequeue();
                        break;
                    case 4:
                        d.PrintQueue();
                        break;
                    case 5:
                        Console.WriteLine("Enter a file type ({ TXT = 1, DOC = 2, DOCX = 3, PDF = 4, PPTX = 5 }):");
                        FileTypeExtension typecheck = getTypeByNum(int.Parse(Console.ReadLine()));

                        QueueFiles dcopy = d;
                        DataFile[] files = dcopy.SearchFileByType(typecheck);
                        if (files != null)
                        {
                            foreach (DataFile file in files)
                                file.Dir(file);
                        }
                        else
                        {
                            Console.WriteLine("No Data Files in queue with this type");
                        }
                        break;
                    case 6:
                        DataFile dbig = new DataFile();
                        if (!d.IsEmpty())
                        {
                            dbig = d.BigFile();
                            Console.Write("The bigget File: ");
                            dbig.Dir(dbig);
                        }
                        else Console.WriteLine("therefore no biggest file was found");
                        break;
                    default:
                        break;
                }
            }
            while (a != 7);
            Console.WriteLine("Thank you!");
        }
    }
}