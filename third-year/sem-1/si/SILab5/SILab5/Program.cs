using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SILab5
{
    class Program
    {
        static void Main(string[] args)
        {
            ConversionHandler myConverter = new ConversionHandler();
            RSACryptoServiceProvider myrsa = new RSACryptoServiceProvider(2048);
            System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch();

            string rsa = myrsa.ToXmlString(true);
            RSAParameters a = myrsa.ExportParameters(true);
            Console.Write(myrsa.ExportParameters(true).ToString());
            //myConverter.ByteArrayToString(myrsa.ExportParameters(true))

            int size;
            int count = 100;
            swatch.Start();
            for (int i = 0; i < count; i++)
            {
                myrsa = new RSACryptoServiceProvider(2048);
                size = myrsa.KeySize;
                Console.Write(i + "\n");
            }
            swatch.Stop();
            Console.WriteLine("Generation time at 1024 bit ... " +
            (swatch.ElapsedTicks / (10 * count)).ToString() + " ms");
            byte[] plain = new byte[20];
            byte[] ciphertext = myrsa.Encrypt(plain, true);
            swatch.Reset();
            swatch.Start();

            for (int i = 0; i < count; i++)
            {
                ciphertext = myrsa.Encrypt(plain, true);
            }
            swatch.Stop();
            Console.WriteLine("Encryption time at 1024 bit ... " +
            (swatch.ElapsedTicks / (10 * count)).ToString() + " ms");
            swatch.Reset();
            swatch.Start();
            for (int i = 0; i < count; i++)
            {
                plain = myrsa.Decrypt(ciphertext, true);
            }
            swatch.Stop();
            Console.WriteLine("Decryption time at 1024 bit ... " +
            (swatch.ElapsedTicks / (10 * count)).ToString() + " ms");


            SHA256Managed myHash = new SHA256Managed();
            string some_text = "this is an important message";
            //sign the message
            byte[] signature;
            swatch.Reset();
            swatch.Start();
            signature = myrsa.SignData(System.Text.Encoding.ASCII.GetBytes(some_text), myHash);
            for (int i = 0; i < count; i++)
            {
                signature = myrsa.SignData(System.Text.Encoding.ASCII.GetBytes(some_text), myHash);
            }

            swatch.Stop();
            Console.WriteLine("Signiture time at 1024 bit ... " +
                (swatch.ElapsedTicks / (10 * count)).ToString() + " ms");

            //verified a signature on a given message
            bool verified;
            swatch.Reset();
            swatch.Start();

            for (int i = 0; i < count; i++)
            {
                verified = myrsa.VerifyData(System.Text.Encoding.ASCII.GetBytes(some_text), myHash, signature);
            }

            swatch.Stop();
            Console.WriteLine("Verification time at 1024 bit ... " +
                (swatch.ElapsedTicks / (10 * count)).ToString() + " ms");
            Console.ReadKey();
        }
    }

    class ConversionHandler
    {
        public byte[] StringToByteArray(string s)
        {
            return CharArrayToByteArray(s.ToCharArray());
        }
        public byte[] CharArrayToByteArray(char[] array)
        {
            return Encoding.ASCII.GetBytes(array, 0, array.Length);
        }
        public string ByteArrayToString(byte[] array)
        {
            return Encoding.ASCII.GetString(array);
        }
        public string ByteArrayToHexString(byte[] array)
        {
            string s = "";
            int i;
            for (i = 0; i < array.Length; i++)
            {
                s = s + NibbleToHexString((byte)((array[i] >> 4) &
               0x0F)) + NibbleToHexString((byte)(array[i] & 0x0F));
            }
            return s;
        }
        public byte[] HexStringToByteArray(string s)
        {
            byte[] array = new byte[s.Length / 2];
            char[] chararray = s.ToCharArray();
            int i;
            for (i = 0; i < s.Length / 2; i++)
            {
                array[i] = (byte)(((HexCharToNibble(chararray[2 * i])
               << 4) & 0xF0) | ((HexCharToNibble(chararray[2
               * i + 1]) & 0x0F)));
            }
            return array;
        }
        public string NibbleToHexString(byte nib)
        {
            string s;
            if (nib < 10)
            {
                s = nib.ToString();
            }
            else
            {
                char c = (char)(nib + 55);
                s = c.ToString();
            }
            return s;
        }
        public byte HexCharToNibble(char c)
        {
            byte value = (byte)c;
            if (value < 65)
            {
                value = (byte)(value - 48);

            }
            else

            {
                value = (byte)(value - 55);

            }
            return value;
        }
    }
}