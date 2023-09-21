﻿using TP.CS.EventsBus.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP.CS.Registry;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassTool.GUI
{
    public class Program
    {
        public static PassTool passTool { get; set; }
        private static CancellationTokenSource token;
        public static Key Hive = new Key("root", null)
        {
            Type = EntryType.Root
        };

        public static int Main(string[] args)
        {
            Session session = new Session();
            Hive=RegistryIO.loadHive("PassTool");
            
            token = new CancellationTokenSource();
            Thread X = new Thread(() =>
            {
                Application.EnableVisualStyles();

                passTool = new PassTool();

                Application.ApplicationExit += Application_ApplicationExit;
                Application.Run(passTool);

                token.Cancel();
            });
            X.Start();

            while (!token.IsCancellationRequested)
            {
                Thread.Sleep(500);
            }
            /*
            Application.Run(passTool);
            */
            return 0;
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            RegistryIO.saveHive(Hive,"PassTool");
        }
    }
}
