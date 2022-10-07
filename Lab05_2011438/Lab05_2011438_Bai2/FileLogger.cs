﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab05_2011438_Bai2
{
    class FileLogger : ILogger
    {
        private static Mutex mutex = new Mutex();
        private StreamWriter output;

        public FileLogger(String filename)
        {
            output = new StreamWriter(filename, true);
        }
        public void writeEntry(ArrayList entry)
        {
            mutex.WaitOne();
            IEnumerator line = entry.GetEnumerator();
            while (line.MoveNext())
                output.WriteLine(line.Current);
            output.Flush();
            mutex.ReleaseMutex();
        }
        public void writeEntry(String entry)
        {
            mutex.WaitOne();
            output.WriteLine(entry);
            output.WriteLine();
            output.Flush();
            mutex.ReleaseMutex();
        }
    }
}
