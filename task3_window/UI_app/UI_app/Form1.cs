using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace key_gen_UI
{
    public partial class Form1 : Form
    {
        [DllImport("key_gen.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "key_gen")]
        private static extern double key_gen(string filePriv, string filePub, int choice);
        [DllImport("encrypt.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "encrypt")]
        private static extern double encrypt(string filePub, int choice, string plain, StringBuilder cipher, StringBuilder popup);
        [DllImport("decrypt.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "decrypt")]
        private static extern double decrypt(string filePub, int choice, string cipher, StringBuilder plain, StringBuilder popup);

        public Form1()
        {
            InitializeComponent();
        }

        private void gen_key_button(object sender, EventArgs e)
        {
            int choice = 0;
            string filePriv = privateKeyTextBox.Text;
            string filePub = publicKeyTextBox.Text;
            if (berButton.Checked)
                choice = 1;
            else if (pemButton.Checked)
                choice = 2; 
            else
                MessageBox.Show("Please choose key format!!");
            double time = 0;
            try
            {
                time = key_gen(filePriv, filePub, choice);
            }
            catch
            {
                MessageBox.Show("Fail to gen key");
            }
            MessageBox.Show("Successfully generate key\nTime for key generation: " + time.ToString() + " ms");
        }

        private void encrypt_button(object sender, EventArgs e)
        {
            int choice = 0;
            if (file.Checked)
            {
                choice = 1;
            }
            else if (keyboard.Checked)
            {
                choice = 2;
            }
            else
                MessageBox.Show("Please choose an option!!!");
            string filePub = pubkeyPath.Text;
            string plain;
            if (choice == 1)
            {
                plain = plaintextPath.Text;
            }
            else
            {
                plain = plaintext.Text;
            }
            int MAXLENGTH = 3072;
            StringBuilder mess = new StringBuilder(MAXLENGTH);
            StringBuilder popup = new StringBuilder(MAXLENGTH);
            double time = encrypt(filePub, choice, plain, mess, popup);
            outputBox.Text = mess.ToString();
            MessageBox.Show(popup.ToString() + "\nTime for encryption: " + time.ToString() + " microseconds");
        }
        private void choosePlainFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                plaintextPath.Text = openFileDialog1.FileName;
            }
        }

        private void choose_pubkey(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                pubkeyPath.Text = openFileDialog2.FileName;
            }
        }

        private void choosePrivateKey(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog3 = new OpenFileDialog();
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                privkeyPath.Text = openFileDialog3.FileName;
            }
        }


        private void decryptButton_Click(object sender, EventArgs e)
        {
            int choice = 0;
            if (file1.Checked)
            {
                choice = 1;
            }
            else if (keyboard1.Checked)
            {
                choice = 2;
            }
            else
                MessageBox.Show("Please choose an option!!!");
            string filePriv = privkeyPath.Text;
            string cipher;
            if (choice == 1)
            {
                cipher = ciphertextPath.Text;
            }
            else
            {
                cipher = ciphertext.Text;
            }
            int MAXLENGTH = 3072;
            StringBuilder plain = new StringBuilder(MAXLENGTH);
            StringBuilder popup = new StringBuilder(MAXLENGTH);
            
            double time = decrypt(filePriv, choice, cipher, plain, popup);
            outputBox1.Text = plain.ToString();
            MessageBox.Show(popup.ToString() + "\nTime for decryption: " + time.ToString() + " microseconds");

        }

        private void chooseCiphertext(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog4 = new OpenFileDialog();
            if (openFileDialog4.ShowDialog() == DialogResult.OK)
            {
                ciphertextPath.Text = openFileDialog4.FileName;
            }
        }

        private void outputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void outputBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
