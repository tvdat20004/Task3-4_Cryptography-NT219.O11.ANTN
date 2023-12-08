namespace UI_task4
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
            this.key_generation = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pemButton = new System.Windows.Forms.RadioButton();
            this.berButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.genKeyButton = new System.Windows.Forms.Button();
            this.privatekeyPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pubkeyPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.signatureBox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.messageBrowser = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.messagePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.keyboard_sign = new System.Windows.Forms.RadioButton();
            this.fromfile_sign = new System.Windows.Forms.RadioButton();
            this.browserPrivkey = new System.Windows.Forms.Button();
            this.sign = new System.Windows.Forms.Button();
            this.privkeyPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Verify = new System.Windows.Forms.TabPage();
            this.signVerify = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.browserMess = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.messPathVerify = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.messageVerify = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.keyboardVerify = new System.Windows.Forms.RadioButton();
            this.fromfileVerify = new System.Windows.Forms.RadioButton();
            this.browserPubkey = new System.Windows.Forms.Button();
            this.verifyButton = new System.Windows.Forms.Button();
            this.pubKey = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.key_generation.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.Verify.SuspendLayout();
            this.SuspendLayout();
            // 
            // key_generation
            // 
            this.key_generation.Controls.Add(this.tabPage1);
            this.key_generation.Controls.Add(this.tabPage2);
            this.key_generation.Controls.Add(this.Verify);
            this.key_generation.Location = new System.Drawing.Point(2, 2);
            this.key_generation.Name = "key_generation";
            this.key_generation.SelectedIndex = 0;
            this.key_generation.Size = new System.Drawing.Size(1043, 634);
            this.key_generation.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pemButton);
            this.tabPage1.Controls.Add(this.berButton);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.genKeyButton);
            this.tabPage1.Controls.Add(this.privatekeyPath);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.pubkeyPath);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1035, 601);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Generate key";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pemButton
            // 
            this.pemButton.AutoSize = true;
            this.pemButton.Location = new System.Drawing.Point(572, 353);
            this.pemButton.Name = "pemButton";
            this.pemButton.Size = new System.Drawing.Size(68, 24);
            this.pemButton.TabIndex = 9;
            this.pemButton.TabStop = true;
            this.pemButton.Text = "PEM";
            this.pemButton.UseVisualStyleBackColor = true;
            // 
            // berButton
            // 
            this.berButton.AutoSize = true;
            this.berButton.Location = new System.Drawing.Point(370, 354);
            this.berButton.Name = "berButton";
            this.berButton.Size = new System.Drawing.Size(68, 24);
            this.berButton.TabIndex = 8;
            this.berButton.TabStop = true;
            this.berButton.Text = "BER";
            this.berButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(115, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Key format";
            // 
            // genKeyButton
            // 
            this.genKeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genKeyButton.Location = new System.Drawing.Point(415, 465);
            this.genKeyButton.Name = "genKeyButton";
            this.genKeyButton.Size = new System.Drawing.Size(198, 53);
            this.genKeyButton.TabIndex = 6;
            this.genKeyButton.Text = "Generate";
            this.genKeyButton.UseVisualStyleBackColor = true;
            this.genKeyButton.Click += new System.EventHandler(this.genKeyButton_Click);
            // 
            // privatekeyPath
            // 
            this.privatekeyPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.privatekeyPath.Location = new System.Drawing.Point(415, 248);
            this.privatekeyPath.Name = "privatekeyPath";
            this.privatekeyPath.Size = new System.Drawing.Size(170, 32);
            this.privatekeyPath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Private key";
            // 
            // pubkeyPath
            // 
            this.pubkeyPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pubkeyPath.Location = new System.Drawing.Point(415, 149);
            this.pubkeyPath.Name = "pubkeyPath";
            this.pubkeyPath.Size = new System.Drawing.Size(170, 32);
            this.pubkeyPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Public key:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.signatureBox);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.messageBrowser);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.messagePath);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.messageBox);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.keyboard_sign);
            this.tabPage2.Controls.Add(this.fromfile_sign);
            this.tabPage2.Controls.Add(this.browserPrivkey);
            this.tabPage2.Controls.Add(this.sign);
            this.tabPage2.Controls.Add(this.privkeyPath);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1035, 601);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sign";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // signatureBox
            // 
            this.signatureBox.Location = new System.Drawing.Point(346, 392);
            this.signatureBox.Name = "signatureBox";
            this.signatureBox.Size = new System.Drawing.Size(490, 88);
            this.signatureBox.TabIndex = 29;
            this.signatureBox.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(127, 425);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 26);
            this.label8.TabIndex = 28;
            this.label8.Text = "Signature";
            // 
            // messageBrowser
            // 
            this.messageBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBrowser.Location = new System.Drawing.Point(733, 324);
            this.messageBrowser.Name = "messageBrowser";
            this.messageBrowser.Size = new System.Drawing.Size(103, 32);
            this.messageBrowser.TabIndex = 27;
            this.messageBrowser.Text = "browser";
            this.messageBrowser.UseVisualStyleBackColor = true;
            this.messageBrowser.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(127, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(270, 26);
            this.label7.TabIndex = 26;
            this.label7.Text = "Message file (if necessary)";
            // 
            // messagePath
            // 
            this.messagePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messagePath.Location = new System.Drawing.Point(463, 324);
            this.messagePath.Name = "messagePath";
            this.messagePath.Size = new System.Drawing.Size(202, 32);
            this.messagePath.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(127, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(236, 26);
            this.label6.TabIndex = 24;
            this.label6.Text = "Message (if necessary)";
            // 
            // messageBox
            // 
            this.messageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBox.Location = new System.Drawing.Point(463, 228);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(202, 32);
            this.messageBox.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(127, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 26);
            this.label4.TabIndex = 22;
            this.label4.Text = "Message to sign:";
            // 
            // keyboard_sign
            // 
            this.keyboard_sign.AutoSize = true;
            this.keyboard_sign.Location = new System.Drawing.Point(603, 129);
            this.keyboard_sign.Name = "keyboard_sign";
            this.keyboard_sign.Size = new System.Drawing.Size(140, 24);
            this.keyboard_sign.TabIndex = 21;
            this.keyboard_sign.TabStop = true;
            this.keyboard_sign.Text = "From keyboard";
            this.keyboard_sign.UseVisualStyleBackColor = true;
            // 
            // fromfile_sign
            // 
            this.fromfile_sign.AutoSize = true;
            this.fromfile_sign.Location = new System.Drawing.Point(401, 130);
            this.fromfile_sign.Name = "fromfile_sign";
            this.fromfile_sign.Size = new System.Drawing.Size(95, 24);
            this.fromfile_sign.TabIndex = 20;
            this.fromfile_sign.TabStop = true;
            this.fromfile_sign.Text = "From file";
            this.fromfile_sign.UseVisualStyleBackColor = true;
            // 
            // browserPrivkey
            // 
            this.browserPrivkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browserPrivkey.Location = new System.Drawing.Point(733, 36);
            this.browserPrivkey.Name = "browserPrivkey";
            this.browserPrivkey.Size = new System.Drawing.Size(103, 32);
            this.browserPrivkey.TabIndex = 18;
            this.browserPrivkey.Text = "browser";
            this.browserPrivkey.UseVisualStyleBackColor = true;
            this.browserPrivkey.Click += new System.EventHandler(this.button2_Click);
            // 
            // sign
            // 
            this.sign.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign.Location = new System.Drawing.Point(451, 499);
            this.sign.Name = "sign";
            this.sign.Size = new System.Drawing.Size(198, 53);
            this.sign.TabIndex = 15;
            this.sign.Text = "Sign";
            this.sign.UseVisualStyleBackColor = true;
            this.sign.Click += new System.EventHandler(this.sign_Click);
            // 
            // privkeyPath
            // 
            this.privkeyPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.privkeyPath.Location = new System.Drawing.Point(463, 36);
            this.privkeyPath.Name = "privkeyPath";
            this.privkeyPath.Size = new System.Drawing.Size(202, 32);
            this.privkeyPath.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(127, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 26);
            this.label5.TabIndex = 11;
            this.label5.Text = "Private key";
            // 
            // Verify
            // 
            this.Verify.Controls.Add(this.signVerify);
            this.Verify.Controls.Add(this.label9);
            this.Verify.Controls.Add(this.browserMess);
            this.Verify.Controls.Add(this.label10);
            this.Verify.Controls.Add(this.messPathVerify);
            this.Verify.Controls.Add(this.label11);
            this.Verify.Controls.Add(this.messageVerify);
            this.Verify.Controls.Add(this.label12);
            this.Verify.Controls.Add(this.keyboardVerify);
            this.Verify.Controls.Add(this.fromfileVerify);
            this.Verify.Controls.Add(this.browserPubkey);
            this.Verify.Controls.Add(this.verifyButton);
            this.Verify.Controls.Add(this.pubKey);
            this.Verify.Controls.Add(this.label13);
            this.Verify.Location = new System.Drawing.Point(4, 29);
            this.Verify.Name = "Verify";
            this.Verify.Padding = new System.Windows.Forms.Padding(3);
            this.Verify.Size = new System.Drawing.Size(1035, 601);
            this.Verify.TabIndex = 2;
            this.Verify.Text = "Verify";
            this.Verify.UseVisualStyleBackColor = true;
            // 
            // signVerify
            // 
            this.signVerify.Location = new System.Drawing.Point(352, 394);
            this.signVerify.Name = "signVerify";
            this.signVerify.Size = new System.Drawing.Size(490, 88);
            this.signVerify.TabIndex = 43;
            this.signVerify.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(133, 427);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 26);
            this.label9.TabIndex = 42;
            this.label9.Text = "Signature to verify";
            // 
            // browserMess
            // 
            this.browserMess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browserMess.Location = new System.Drawing.Point(739, 326);
            this.browserMess.Name = "browserMess";
            this.browserMess.Size = new System.Drawing.Size(103, 32);
            this.browserMess.TabIndex = 41;
            this.browserMess.Text = "browser";
            this.browserMess.UseVisualStyleBackColor = true;
            this.browserMess.Click += new System.EventHandler(this.browserMess_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(133, 332);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(276, 26);
            this.label10.TabIndex = 40;
            this.label10.Text = "Message file: (if necessary)";
            // 
            // messPathVerify
            // 
            this.messPathVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messPathVerify.Location = new System.Drawing.Point(469, 326);
            this.messPathVerify.Name = "messPathVerify";
            this.messPathVerify.Size = new System.Drawing.Size(202, 32);
            this.messPathVerify.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(133, 236);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(236, 26);
            this.label11.TabIndex = 38;
            this.label11.Text = "Message (if necessary)";
            // 
            // messageVerify
            // 
            this.messageVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageVerify.Location = new System.Drawing.Point(469, 230);
            this.messageVerify.Name = "messageVerify";
            this.messageVerify.Size = new System.Drawing.Size(202, 32);
            this.messageVerify.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(133, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(188, 26);
            this.label12.TabIndex = 36;
            this.label12.Text = "Message to verify:";
            // 
            // keyboardVerify
            // 
            this.keyboardVerify.AutoSize = true;
            this.keyboardVerify.Location = new System.Drawing.Point(609, 131);
            this.keyboardVerify.Name = "keyboardVerify";
            this.keyboardVerify.Size = new System.Drawing.Size(140, 24);
            this.keyboardVerify.TabIndex = 35;
            this.keyboardVerify.TabStop = true;
            this.keyboardVerify.Text = "From keyboard";
            this.keyboardVerify.UseVisualStyleBackColor = true;
            // 
            // fromfileVerify
            // 
            this.fromfileVerify.AutoSize = true;
            this.fromfileVerify.Location = new System.Drawing.Point(407, 132);
            this.fromfileVerify.Name = "fromfileVerify";
            this.fromfileVerify.Size = new System.Drawing.Size(95, 24);
            this.fromfileVerify.TabIndex = 34;
            this.fromfileVerify.TabStop = true;
            this.fromfileVerify.Text = "From file";
            this.fromfileVerify.UseVisualStyleBackColor = true;
            // 
            // browserPubkey
            // 
            this.browserPubkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browserPubkey.Location = new System.Drawing.Point(739, 38);
            this.browserPubkey.Name = "browserPubkey";
            this.browserPubkey.Size = new System.Drawing.Size(103, 32);
            this.browserPubkey.TabIndex = 33;
            this.browserPubkey.Text = "browser";
            this.browserPubkey.UseVisualStyleBackColor = true;
            this.browserPubkey.Click += new System.EventHandler(this.browserPubkey_Click);
            // 
            // verifyButton
            // 
            this.verifyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifyButton.Location = new System.Drawing.Point(457, 501);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(198, 53);
            this.verifyButton.TabIndex = 32;
            this.verifyButton.Text = "Verify";
            this.verifyButton.UseVisualStyleBackColor = true;
            this.verifyButton.Click += new System.EventHandler(this.signButton_Click);
            // 
            // pubKey
            // 
            this.pubKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pubKey.Location = new System.Drawing.Point(469, 38);
            this.pubKey.Name = "pubKey";
            this.pubKey.Size = new System.Drawing.Size(202, 32);
            this.pubKey.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(133, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 26);
            this.label13.TabIndex = 30;
            this.label13.Text = "Public key:";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 639);
            this.Controls.Add(this.key_generation);
            this.Name = "Form1";
            this.Text = "Form1";
            this.key_generation.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.Verify.ResumeLayout(false);
            this.Verify.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl key_generation;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox pubkeyPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox privatekeyPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button genKeyButton;
        private System.Windows.Forms.Button sign;
        private System.Windows.Forms.TextBox privkeyPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton pemButton;
        private System.Windows.Forms.RadioButton berButton;
        private System.Windows.Forms.Button browserPrivkey;
        private System.Windows.Forms.RadioButton keyboard_sign;
        private System.Windows.Forms.RadioButton fromfile_sign;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox messagePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button messageBrowser;
        private System.Windows.Forms.RichTextBox signatureBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage Verify;
        private System.Windows.Forms.RichTextBox signVerify;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button browserMess;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox messPathVerify;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox messageVerify;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton keyboardVerify;
        private System.Windows.Forms.RadioButton fromfileVerify;
        private System.Windows.Forms.Button browserPubkey;
        private System.Windows.Forms.Button verifyButton;
        private System.Windows.Forms.TextBox pubKey;
        private System.Windows.Forms.Label label13;
    }
}

