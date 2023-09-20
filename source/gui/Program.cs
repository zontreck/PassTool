using CS.TPEventsBus.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//[assembly:EventBusBroadcastable()]
namespace PassTool.GUI
{
    public class Program
    {
        public static PassTool PassTool { get; set; } = new();
        public static int Main(string[] args)
        {
            Application.Run(PassTool);
            
            return 0;
        }
    }
}
