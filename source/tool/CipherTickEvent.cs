using CS.TPEventsBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassTool
{
    /// <summary>
    /// This event is dispatched when another digit in the password has been generated
    /// </summary>
    public class CipherTickEvent : Event
    {
        public int Length;
        public string Pass;

        public int MaxLen;
        public CipherTickEvent(string Pass, int MaxLength) 
        {
            this.Pass = Pass;
            Length = Pass.Length;

            MaxLen = MaxLength;
        }

    }
}
