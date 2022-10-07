﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab05_2011438_Bai2
{
    internal class TcpEchoServerThread
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
                throw new ArgumentException("Parameter(s): <Port>");
            int serverPort = Int32.Parse(args[0]);
            TcpListener listener = new TcpListener(IPAddress.Any, serverPort);
            ILogger logger = new ConsoleLogger();
            listener.Start();
            for (; ; )
            {
                try
                {
                    Socket client = listener.AcceptSocket();
                    EchoProtocol protocol = new EchoProtocol(client, logger);
                    Thread thread = new Thread(new ThreadStart(protocol.handleclient));
                    thread.Start();
                    logger.writeEntry("Created and started Thread = " + thread.GetHashCode());
                }
                catch (System.IO.IOException e)
                {
                    logger.writeEntry("Error:" + e.Message);
                }
            }
        }
    }
}
