﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.CS.EventsBus.Attributes;
using Prebuild.Core.Utilities;

namespace PassTool
{
    public class Program
    {
        public static int Main(string[] args)
        {
            //var debugArgs = new string[] { "/cipher", "This is a test", "/length", "20", "/seed", "154368288" };
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
                    $"Version: {GitVersion.FullVersion}\n" +
                    "(c) 2023 Tara Piccari\n" +
                    "\n" +
                    "/cipher [text]             The ciphertext to transform\n" +
                    "/seed [number]             The seed used to transform the cipher\n" +
                    "/length [number]           The final length of the password\n" +
                    "/silent                    Prevents printing out the parameters and version header along with the final password\n" +
                    "/usage                     Print this message\n\n");

                return 1;
            }

            if(!arguments.WasPassed("silent"))
            {

                Console.WriteLine("" +

                        "PassTool\n" +
                        $"Version: {GitVersion.FullVersion}\n\n");
                Console.WriteLine($"CipherText: {cipher}");
                Console.WriteLine($"Seed: {seed}");
                Console.WriteLine($"Length: {len}");
            }
            Console.WriteLine(CipherPassword.Manipulate(cipher, seed, len));

            return 0;
        }
    }
}
