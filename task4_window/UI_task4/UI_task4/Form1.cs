using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace UI_task4
{
    public partial class Form1 : Form
    {
        [DllImport("key_gen.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "key_gen")]
        private static extern bool key_gen(string filePub, string filePriv, int chocice);
        [DllImport("sign.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "SignMessage")]
        private static extern void SignMessage(string filekey, string message, StringBuilder signature, StringBuilder popup, int choice);
        [DllImport("verify.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "VerifyMessage")]
        private static extern void VerifyMessage(string filekey,int choice, string message, string signHex, StringBuilder popup);

        public Form1()
        {
            InitializeComponent();
        }
        private void genKeyButton_Click(object sender, EventArgs e)
        {
            int choice = 0;
            if (berButton.Checked)
            {
                choice = 1;
            }
            else if (pemButton.Checked)
            {
                choice = 2;
            }
            else
                MessageBox.Show("Please choose key format!!!");

            string filePriv = privatekeyPath.Text;
            string filePub = pubkeyPath.Text;
            bool check = key_gen(filePub, filePriv, choice);
            if (check)
            {
                MessageBox.Show("Successfully generate key!!");
            }
            else
            {
                MessageBox.Show("Fail to generate key!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPrivateKey = new OpenFileDialog();
            if (openPrivateKey.ShowDialog() == DialogResult.OK)
            {
                privkeyPath.Text = openPrivateKey.FileName;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openMess = new OpenFileDialog();
            if (openMess.ShowDialog() == DialogResult.OK)
            {
                messagePath.Text = openMess.FileName;
            }
        }

        private void sign_Click(object sender, EventArgs e)
        {
            int MAXLENGTH = 3072;
            int choice = 0;
            if (fromfile_sign.Checked)
            {
                choice = 1;
            }
            else if (keyboard_sign.Checked)
            {
                choice = 2;
            }

            StringBuilder signature = new StringBuilder(MAXLENGTH);
            StringBuilder popup = new StringBuilder(MAXLENGTH);
            string message;
            if (choice == 1)
            {
                message = messagePath.Text;
            }
            else
            {
                message = messageBox.Text;
            }
            string fileKey = privkeyPath.Text;
            SignMessage(fileKey, message, signature, popup, choice);
            signatureBox.Text = signature.ToString();
            MessageBox.Show(popup.ToString());
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void signButton_Click(object sender, EventArgs e)
        {
            int MAXLENGTH = 3072;
            int choice = 0;
            if (fromfileVerify.Checked)
            {
                choice = 1;
            }
            else if (keyboardVerify.Checked)
            {
                choice = 2;
            }
            StringBuilder popup = new StringBuilder(MAXLENGTH);
            string message;
            if (choice == 1)
            {
                message = messPathVerify.Text;
            }
            else
            {
                message = messageVerify.Text;
            }
            string signature = signatureBox.Text;
            string fileKey = pubKey.Text;
            VerifyMessage(fileKey, choice, message, signature, popup);
            MessageBox.Show(popup.ToString());
        }

        private void browserPubkey_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPublicKey = new OpenFileDialog();
            if (openPublicKey.ShowDialog() == DialogResult.OK)
            {
                pubKey.Text = openPublicKey.FileName;
            }
        }

        private void browserMess_Click(object sender, EventArgs e)
        {
            OpenFileDialog openMess = new OpenFileDialog();
            if (openMess.ShowDialog() == DialogResult.OK)
            {
                messPathVerify.Text = openMess.FileName;
            }
        }
    }
}
