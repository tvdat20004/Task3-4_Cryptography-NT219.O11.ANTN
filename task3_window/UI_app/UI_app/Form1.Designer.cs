namespace key_gen_UI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.berButton = new System.Windows.Forms.RadioButton();
            this.pemButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.publicKeyTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.privateKeyTextBox = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.choosePubKey = new System.Windows.Forms.Button();
            this.choosePlainPath = new System.Windows.Forms.Button();
            this.plaintextPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.encButton = new System.Windows.Forms.Button();
            this.plaintext = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pubkeyPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.file = new System.Windows.Forms.RadioButton();
            this.keyboard = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.outputBox1 = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ciphertextPath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.decryptButton = new System.Windows.Forms.Button();
            this.ciphertext = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.privkeyPath = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.file1 = new System.Windows.Forms.RadioButton();
            this.keyboard1 = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1069, 579);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.berButton);
            this.tabPage1.Controls.Add(this.pemButton);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.publicKeyTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.privateKeyTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1061, 546);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Key generation";
            // 
            // berButton
            // 
            this.berButton.AutoSize = true;
            this.berButton.Location = new System.Drawing.Point(704, 211);
            this.berButton.Name = "berButton";
            this.berButton.Size = new System.Drawing.Size(118, 24);
            this.berButton.TabIndex = 7;
            this.berButton.TabStop = true;
            this.berButton.Text = "BER format";
            this.berButton.UseVisualStyleBackColor = true;
            // 
            // pemButton
            // 
            this.pemButton.AutoSize = true;
            this.pemButton.Location = new System.Drawing.Point(704, 130);
            this.pemButton.Name = "pemButton";
            this.pemButton.Size = new System.Drawing.Size(118, 24);
            this.pemButton.TabIndex = 6;
            this.pemButton.TabStop = true;
            this.pemButton.Text = "PEM format";
            this.pemButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button1.Location = new System.Drawing.Point(673, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 54);
            this.button1.TabIndex = 5;
            this.button1.TabStop = false;
            this.button1.Text = "Gen key";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.gen_key_button);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Public key:";
            // 
            // publicKeyTextBox
            // 
            this.publicKeyTextBox.Location = new System.Drawing.Point(130, 218);
            this.publicKeyTextBox.Name = "publicKeyTextBox";
            this.publicKeyTextBox.Size = new System.Drawing.Size(372, 39);
            this.publicKeyTextBox.TabIndex = 3;
            this.publicKeyTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Private key:";
            // 
            // privateKeyTextBox
            // 
            this.privateKeyTextBox.Location = new System.Drawing.Point(130, 111);
            this.privateKeyTextBox.Name = "privateKeyTextBox";
            this.privateKeyTextBox.Size = new System.Drawing.Size(372, 39);
            this.privateKeyTextBox.TabIndex = 1;
            this.privateKeyTextBox.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.outputBox);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.choosePubKey);
            this.tabPage2.Controls.Add(this.choosePlainPath);
            this.tabPage2.Controls.Add(this.plaintextPath);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.encButton);
            this.tabPage2.Controls.Add(this.plaintext);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.pubkeyPath);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.file);
            this.tabPage2.Controls.Add(this.keyboard);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1061, 546);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Encrypt";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(270, 336);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(667, 102);
            this.outputBox.TabIndex = 17;
            this.outputBox.Text = "";
            this.outputBox.TextChanged += new System.EventHandler(this.outputBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(101, 357);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 32);
            this.label7.TabIndex = 16;
            this.label7.Text = "Output";
            // 
            // choosePubKey
            // 
            this.choosePubKey.Location = new System.Drawing.Point(846, 38);
            this.choosePubKey.Name = "choosePubKey";
            this.choosePubKey.Size = new System.Drawing.Size(91, 34);
            this.choosePubKey.TabIndex = 15;
            this.choosePubKey.Text = "Browser";
            this.choosePubKey.UseVisualStyleBackColor = true;
            this.choosePubKey.Click += new System.EventHandler(this.choose_pubkey);
            // 
            // choosePlainPath
            // 
            this.choosePlainPath.Location = new System.Drawing.Point(846, 262);
            this.choosePlainPath.Name = "choosePlainPath";
            this.choosePlainPath.Size = new System.Drawing.Size(91, 34);
            this.choosePlainPath.TabIndex = 14;
            this.choosePlainPath.Text = "Browser";
            this.choosePlainPath.UseVisualStyleBackColor = true;
            this.choosePlainPath.Click += new System.EventHandler(this.choosePlainFile);
            // 
            // plaintextPath
            // 
            this.plaintextPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plaintextPath.Location = new System.Drawing.Point(561, 266);
            this.plaintextPath.Name = "plaintextPath";
            this.plaintextPath.Size = new System.Drawing.Size(256, 30);
            this.plaintextPath.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(102, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(281, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Plaintext path (if necessary)";
            // 
            // encButton
            // 
            this.encButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.encButton.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encButton.ForeColor = System.Drawing.SystemColors.WindowText;
            this.encButton.Location = new System.Drawing.Point(446, 470);
            this.encButton.Name = "encButton";
            this.encButton.Size = new System.Drawing.Size(210, 54);
            this.encButton.TabIndex = 10;
            this.encButton.TabStop = false;
            this.encButton.Text = "Encrypt";
            this.encButton.UseVisualStyleBackColor = true;
            this.encButton.Click += new System.EventHandler(this.encrypt_button);
            // 
            // plaintext
            // 
            this.plaintext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plaintext.Location = new System.Drawing.Point(561, 195);
            this.plaintext.Name = "plaintext";
            this.plaintext.Size = new System.Drawing.Size(256, 30);
            this.plaintext.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(102, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(233, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Plaintext (if necessary)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(102, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "From file/keyboard";
            // 
            // pubkeyPath
            // 
            this.pubkeyPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pubkeyPath.Location = new System.Drawing.Point(561, 42);
            this.pubkeyPath.Name = "pubkeyPath";
            this.pubkeyPath.Size = new System.Drawing.Size(256, 30);
            this.pubkeyPath.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(102, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Public key:";
            // 
            // file
            // 
            this.file.AutoSize = true;
            this.file.Location = new System.Drawing.Point(561, 123);
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(95, 24);
            this.file.TabIndex = 1;
            this.file.Text = "From file";
            this.file.UseVisualStyleBackColor = true;
            // 
            // keyboard
            // 
            this.keyboard.AutoSize = true;
            this.keyboard.Checked = true;
            this.keyboard.Location = new System.Drawing.Point(733, 123);
            this.keyboard.Name = "keyboard";
            this.keyboard.Size = new System.Drawing.Size(140, 24);
            this.keyboard.TabIndex = 0;
            this.keyboard.TabStop = true;
            this.keyboard.Text = "From keyboard";
            this.keyboard.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.outputBox1);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.ciphertextPath);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.decryptButton);
            this.tabPage3.Controls.Add(this.ciphertext);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.privkeyPath);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.file1);
            this.tabPage3.Controls.Add(this.keyboard1);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1061, 546);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Decrypt";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // outputBox1
            // 
            this.outputBox1.Location = new System.Drawing.Point(268, 337);
            this.outputBox1.Name = "outputBox1";
            this.outputBox1.Size = new System.Drawing.Size(667, 102);
            this.outputBox1.TabIndex = 31;
            this.outputBox1.Text = "";
            this.outputBox1.TextChanged += new System.EventHandler(this.outputBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(99, 358);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 32);
            this.label8.TabIndex = 30;
            this.label8.Text = "Output";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(844, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 34);
            this.button2.TabIndex = 29;
            this.button2.Text = "Browser";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.choosePrivateKey);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(844, 263);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 34);
            this.button3.TabIndex = 28;
            this.button3.Text = "Browser";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.chooseCiphertext);
            // 
            // ciphertextPath
            // 
            this.ciphertextPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ciphertextPath.Location = new System.Drawing.Point(559, 267);
            this.ciphertextPath.Name = "ciphertextPath";
            this.ciphertextPath.Size = new System.Drawing.Size(256, 30);
            this.ciphertextPath.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(100, 267);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(297, 25);
            this.label9.TabIndex = 26;
            this.label9.Text = "Ciphertext path (if necessary)";
            // 
            // decryptButton
            // 
            this.decryptButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.decryptButton.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decryptButton.ForeColor = System.Drawing.SystemColors.WindowText;
            this.decryptButton.Location = new System.Drawing.Point(444, 471);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(210, 54);
            this.decryptButton.TabIndex = 25;
            this.decryptButton.TabStop = false;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // ciphertext
            // 
            this.ciphertext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ciphertext.Location = new System.Drawing.Point(559, 196);
            this.ciphertext.Name = "ciphertext";
            this.ciphertext.Size = new System.Drawing.Size(256, 30);
            this.ciphertext.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(100, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(249, 25);
            this.label10.TabIndex = 23;
            this.label10.Text = "Ciphertext (if necessary)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(100, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(191, 25);
            this.label11.TabIndex = 22;
            this.label11.Text = "From file/keyboard";
            // 
            // privkeyPath
            // 
            this.privkeyPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.privkeyPath.Location = new System.Drawing.Point(559, 43);
            this.privkeyPath.Name = "privkeyPath";
            this.privkeyPath.Size = new System.Drawing.Size(256, 30);
            this.privkeyPath.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(100, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 25);
            this.label12.TabIndex = 20;
            this.label12.Text = "Private key:";
            // 
            // file1
            // 
            this.file1.AutoSize = true;
            this.file1.Location = new System.Drawing.Point(559, 124);
            this.file1.Name = "file1";
            this.file1.Size = new System.Drawing.Size(95, 24);
            this.file1.TabIndex = 19;
            this.file1.Text = "From file";
            this.file1.UseVisualStyleBackColor = true;
            // 
            // keyboard1
            // 
            this.keyboard1.AutoSize = true;
            this.keyboard1.Checked = true;
            this.keyboard1.Location = new System.Drawing.Point(731, 124);
            this.keyboard1.Name = "keyboard1";
            this.keyboard1.Size = new System.Drawing.Size(140, 24);
            this.keyboard1.TabIndex = 18;
            this.keyboard1.TabStop = true;
            this.keyboard1.Text = "From keyboard";
            this.keyboard1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 586);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox privateKeyTextBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox publicKeyTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton berButton;
        private System.Windows.Forms.RadioButton pemButton;
        private System.Windows.Forms.RichTextBox outputBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button choosePubKey;
        private System.Windows.Forms.Button choosePlainPath;
        private System.Windows.Forms.TextBox plaintextPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button encButton;
        private System.Windows.Forms.TextBox plaintext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pubkeyPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton file;
        private System.Windows.Forms.RadioButton keyboard;
        private System.Windows.Forms.RichTextBox outputBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox ciphertextPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.TextBox ciphertext;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox privkeyPath;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton file1;
        private System.Windows.Forms.RadioButton keyboard1;
    }
}

