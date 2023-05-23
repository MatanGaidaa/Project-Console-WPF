using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Exe3_OrelOssi_LinEini
{
    internal static class CompareFiles
    {
        public static bool EqualFiles(DataFile d1, DataFile d2)
        {
            if (d1.getFileName() == d2.getFileName() && d1.getData() ==
            d2.getData())
                return true;
            return false;
        }
        public static int CompareSizeFiles(DataFile d1, DataFile d2)
        {
            if (d1.getData() == null && d2.getData() == null)
            {
                return 0;
            }
            else if (d1.getData() == null)
            {
                return -1;
            }
            else if (d2.getData() == null)
            {
                return 1;
            }
            if (d1.getData().Length > d2.getData().Length)
            {
                return 1;
            }
            else if (d1.getData().Length < d2.getData().Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
