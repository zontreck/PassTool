using TP.CS.EventsBus.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassTool.GUI
{
    public class Program
    {
        public static PassTool passTool { get; set; }
        private static CancellationTokenSource token;
        public static int Main(string[] args)
        {
            token = new CancellationTokenSource();
            Thread X = new Thread(() =>
            {
                Application.EnableVisualStyles();

                passTool = new PassTool();
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
    }
}
