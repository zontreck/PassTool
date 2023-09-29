using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TP.CS.EventsBus;
using LibAC;


namespace PassTool
{
    public class CipherPassword
    {
        public static List<long> BLACKLIST = new();

        public static string Manipulate(string rawText, long seed, int length=16)
        {
            
            var result = Encoding.UTF8.GetBytes(Tools.ZHS(rawText, length));


            long oldSeed = seed;
            List<long> source = new();
            foreach(byte s in result)
            {
                source.Add(s);
            }

            List<long> pwd = new(new long[length] );
            int P = 0;
            foreach(long X in source)
            {
                if (P >= length) P = 0;
                pwd[P] += X;

                P++;
            }

            source = new List<long>(pwd);

            P = 0;
            foreach(long X in pwd.ToArray())
            {
                pwd[P] = (X ^ seed) + (X + seed);

                P++;
            }


            int MIN = 32;
            int MAX = 126;
            P = 0;
            List<long> used = new();

            foreach(long X in pwd.ToArray())
            {
                bool found = false;
                long VAL = X;

                int tries = 0; // MAX TRIES = 255
                Thread.Sleep(5);
                
                while (!found)
                {
                    Thread.Sleep(25);
                    
                    while (VAL > MAX)
                    {
                        VAL = VAL >> 2;
                    }

                    if (VAL < MAX && VAL > MIN && !used.Contains(VAL) && !BLACKLIST.Contains(VAL) || tries > 255 && !BLACKLIST.Contains(VAL))
                    {
                        used.Add(VAL);
                        // OK
                        found = true;

                        // If the event bus cancels this, abort immediately.
                        if (EventBus.Broadcast(new CipherTickEvent(makePass(pwd.Take(P).ToList()), length))) return "ABORT";
                        //Console.Write((char)(int)VAL);
                        break;
                    }
                    else
                    {
                        if ((seed & 1) == 1)
                        {
                            VAL += VAL % 2;
                        }
                        if ((seed & 2) == 2)
                        {
                            VAL += VAL % 3;
                        }

                        if ((seed & 4) == 4)
                        {
                            VAL += VAL % 4;
                        }

                        if ((seed & 8) == 8)
                        {
                            VAL += 3;
                        }

                        if ((seed & 16) == 16)
                        {
                            VAL += 9;
                        }

                        if ((seed & 32) == 32)
                        {
                            VAL += seed;
                        }

                        if ((seed & 64) == 64)
                        {
                            VAL += VAL % 10;
                        }

                        if ((seed & 128) == 128)
                        {
                            VAL /= 2;
                        }

                        if((seed & 256) == 256)
                        {
                            VAL /= 3;
                        }

                        VAL += (seed & 1 | 2 | 4 | 8 | 16 | 32 | 64 | 128 | 256);
                        VAL += source[P];
                        try
                        {
                            seed += (source[P] * P);

                        }catch(Exception e)
                        {
                            seed /= (source[P]);
                        }

                        tries++;
                    }
                }
                

                pwd[P] = VAL;
                P++;
            }

            string ret = makePass(pwd);
            EventBus.Broadcast(new CipherTickEvent(ret, length));
            return ret;
        }

        public static string makePass(List<long> pwd)
        {
            string ret = "";
            foreach (long X in pwd)
            {
                char V = (char)(int)X;
                ret += V;
            }

            return ret;
        }
    }
}
