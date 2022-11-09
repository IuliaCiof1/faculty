using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SILab5;
namespace SILab5
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DSACryptoServiceProvider mydsa = new DSACryptoServiceProvider(2048);
            System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch();

            //string rsa = myrsa.ToXmlString(true);
            //DSAParameters a = myrsa.ExportParameters(true);
            //Console.Write(myrsa.ExportParameters(true).ToString());
            //myConverter.ByteArrayToString(myrsa.ExportParameters(true))

            int size;
            int count = 100;
            swatch.Start();
            for (int i = 0; i < count; i++)
            {
                mydsa = new DSACryptoServiceProvider(512);
                //size = myrsa.KeySize;
                Console.Write(i + "\n");
            }
            swatch.Stop();
            Console.WriteLine("Generation time at 1024 bit ... " +
            (swatch.ElapsedTicks / (10 * count)).ToString() + " ms");


            SHA256Managed myHash = new SHA256Managed();
            string some_text = "this is an important message";
            //sign the message
            byte[] signature;
            swatch.Reset();
            swatch.Start();
            signature = mydsa.SignData(System.Text.Encoding.ASCII.GetBytes(some_text));
            for (int i = 0; i < count; i++)
            {
                signature = mydsa.SignData(System.Text.Encoding.ASCII.GetBytes(some_text));
            }

            swatch.Stop();
            Console.WriteLine("Signiture time at 1024 bit ... " +
                (swatch.ElapsedTicks / (10 * count)).ToString() + " ms");

            //verified a signature on a given message
            bool verified;
            swatch.Reset();
            swatch.Start();
            verified = mydsa.VerifyData(System.Text.Encoding.ASCII.GetBytes(some_text), signature);
            for (int i = 0; i < count; i++)
            {
                verified = mydsa.VerifyData(System.Text.Encoding.ASCII.GetBytes(some_text), signature);
            }

            swatch.Stop();
            Console.WriteLine("Verification time at 1024 bit ... " +
                (swatch.ElapsedTicks / (10 * count)).ToString() + " ms");
            Console.ReadKey();
        }
    }
}
