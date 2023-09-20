using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prebuild.Core.Utilities;

namespace PassTool
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var arguments = new CommandLineCollection(args);

            Random rng = new Random();
            string cipher = "";
            if(arguments.WasPassed("cipher"))
            {
                cipher = arguments["cipher"];
            }

            int seed = rng.Next();
            if(arguments.WasPassed("seed"))
            {
                seed = int.Parse(arguments["seed"]);
            }

            int len = 16;
            if (arguments.WasPassed("length")) len = int.Parse(arguments["length"]);


            if(cipher == "" || seed == 0 || arguments.WasPassed("usage"))
            {
                if (args.Length == 0) Console.WriteLine("Arguments were not supplied");
                Console.WriteLine("" +
                    "PassTool\n" +
                    "(c) 2023 Tara Piccari\n\n" +
                    "/cipher [text]             The ciphertext to transform\n" +
                    "/seed [number]             The seed used to transform the cipher\n" +
                    "/length [number]           The final length of the password\n" +
                    "/usage                     Print this message\n\n");

                return 1;
            }

            Console.WriteLine($"CipherText: {cipher}");
            Console.WriteLine($"Seed: {seed}");
            Console.WriteLine($"Length: {len}");
            Console.WriteLine(CipherPassword.Manipulate(cipher, seed, len));

            return 0;
        }
    }
}
