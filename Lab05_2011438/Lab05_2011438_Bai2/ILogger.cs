using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05_2011438_Bai2
{
    interface ILogger
    {
        void writeEntry(ArrayList entry);
        void writeEntry(String entry);
    }
}
