using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_ex12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
       
        public void RSA()
        {
            ConversionHandler myConverter = new ConversionHandler();
            RSACryptoServiceProvider myrsa = new RSACryptoServiceProvider(1024);
            System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch();

            string rsa = myrsa.ToXmlString(true);
            RSAParameters a = myrsa.ExportParameters(true);
            Console.Write(myrsa.ExportParameters(true).ToString());
            //myConverter.ByteArrayToString(myrsa.ExportParameters(true))

            int size;
            int count = 100;
            swatch.Start();
            //for (int i = 0; i < count; i++)
            //{
                myrsa = new RSACryptoServiceProvider(2048);
                size = myrsa.KeySize;
               // Console.Write(i + "\n");
            //}
            swatch.Stop();
            string keyGenTime = (swatch.ElapsedTicks / (10 * count)).ToString() + " ms";

            dataGridView1.Rows.Add("Key Generation Time", keyGenTime);


            //Encryption Time
            byte[] plain = new byte[20];
            byte[] ciphertext = myrsa.Encrypt(plain, true);
            swatch.Reset();
            swatch.Start();

            for (int i = 0; i < count; i++)
            {
                ciphertext = myrsa.Encrypt(plain, true);
            }

            swatch.Stop();
            string encTime= (swatch.ElapsedTicks / (10 * count)).ToString() + " ms";
            
            dataGridView1.Rows.Add("Encryption Time", encTime);

            //Decryption Time
            swatch.Reset();
            swatch.Start();
           
            for (int i = 0; i < count; i++)
            {
                plain = myrsa.Decrypt(ciphertext, true);
            }
            swatch.Stop();
            string decTime = (swatch.ElapsedTicks / (10 * count)).ToString() + " ms";
            
            dataGridView1.Rows.Add("Decryption Time", decTime);


            //Signing Time 
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
            string signTime = (swatch.ElapsedTicks / (10 * count)).ToString() + " ms";
            
            dataGridView1.Rows.Add("Signing Time", signTime);


            //verified a signature on a given message
            bool verified;
            swatch.Reset();
            swatch.Start();

            for (int i = 0; i < count; i++)
            {
                verified = myrsa.VerifyData(System.Text.Encoding.ASCII.GetBytes(some_text), myHash, signature);
            }

            swatch.Stop();
            string verifTime = (swatch.ElapsedTicks / (10 * count)).ToString() + " ms";
            
            dataGridView1.Rows.Add("Verification Time", verifTime);
            
        }

        private void btnRsa_Click(object sender, EventArgs e)
        {
            RSA();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void DSA()
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
            string keyGenTime = (swatch.ElapsedTicks / (10 * count)).ToString() + " ms";

            dataGridView2.Rows.Add("Key Generation Time", keyGenTime);


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
            string signTime = (swatch.ElapsedTicks / (10 * count)).ToString() + " ms";

            dataGridView2.Rows.Add("Signing Time", signTime);

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
            string verifTime = (swatch.ElapsedTicks / (10 * count)).ToString() + " ms";

            dataGridView2.Rows.Add("Verification Time", verifTime);
        }

        private void btnDSA_Click(object sender, EventArgs e)
        {
            DSA();
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
