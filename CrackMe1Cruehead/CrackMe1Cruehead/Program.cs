using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackMe1Cruehead
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("== Crackme v1.0 by Cruehead/MiB KeyGen by Studiosi ==\r\n");

            // Get name
            Console.Write("Name: ");
            string name = Console.ReadLine();

            // Calculate name chksum
            byte[] ascName = Encoding.ASCII.GetBytes(name);
            UInt32 r1 = 0;
            foreach(byte c in ascName)
            {
                if(c < 0x41)
                {
                    Console.WriteLine("Invalid Name (only ASCII > 0x41 chars)");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    byte x = c;
                    if (x >= 0x5A)
                        x = (byte)(x - 0x20);
                    r1 += x;                
                }
            }
            r1 = r1 ^ 0x5678;

            // Search proper valid serial
            UInt32 r2 = r1 ^ 0x1234; // XOR is a reversible op
            Console.Write("Serial: ");
            Console.WriteLine("{0}", r2);

            Console.ReadLine();
        }

    }
}
