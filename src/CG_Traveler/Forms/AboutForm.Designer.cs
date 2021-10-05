namespace CG.Traveler.Forms
{
    partial class AboutForm
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
            this._buttonOk = new System.Windows.Forms.Button();
            this._labelTitle = new System.Windows.Forms.Label();
            this._labelCopyright = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._linkLabelFont = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this._linkLabelCode = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this._linkLabelCodeGator = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this._linkLabelScreenSaver = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Image = global::CG.Traveler.Properties.Resources.ni0016_24;
            this._buttonOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._buttonOk.Location = new System.Drawing.Point(218, 267);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(89, 38);
            this._buttonOk.TabIndex = 9;
            this._buttonOk.Text = "  Ok";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // _labelTitle
            // 
            this._labelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._labelTitle.Location = new System.Drawing.Point(12, 18);
            this._labelTitle.Name = "_labelTitle";
            this._labelTitle.Size = new System.Drawing.Size(504, 35);
            this._labelTitle.TabIndex = 10;
            this._labelTitle.Text = "CG_Traveler 1.0.0.0";
            this._labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _labelCopyright
            // 
            this._labelCopyright.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this._labelCopyright.Location = new System.Drawing.Point(12, 55);
            this._labelCopyright.Name = "_labelCopyright";
            this._labelCopyright.Size = new System.Drawing.Size(504, 23);
            this._labelCopyright.TabIndex = 11;
            this._labelCopyright.Text = "Copyright (c) 2005 - 2021 by CodeGator. All rights reserved.";
            this._labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Traveler Font:";
            // 
            // _linkLabelFont
            // 
            this._linkLabelFont.AutoSize = true;
            this._linkLabelFont.Location = new System.Drawing.Point(104, 91);
            this._linkLabelFont.Name = "_linkLabelFont";
            this._linkLabelFont.Size = new System.Drawing.Size(371, 17);
            this._linkLabelFont.TabIndex = 13;
            this._linkLabelFont.TabStop = true;
            this._linkLabelFont.Text = "https://www.therpf.com/forums/threads/travelers-font.299039/";
            this._linkLabelFont.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._linkLabelFont_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Code:";
            // 
            // _linkLabelCode
            // 
            this._linkLabelCode.AutoSize = true;
            this._linkLabelCode.Location = new System.Drawing.Point(104, 157);
            this._linkLabelCode.Name = "_linkLabelCode";
            this._linkLabelCode.Size = new System.Drawing.Size(241, 17);
            this._linkLabelCode.TabIndex = 15;
            this._linkLabelCode.TabStop = true;
            this._linkLabelCode.Text = "http://github.com/codegator/cg.traveler";
            this._linkLabelCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._linkLabelCode_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "CodeGator:";
            // 
            // _linkLabelCodeGator
            // 
            this._linkLabelCodeGator.AutoSize = true;
            this._linkLabelCodeGator.Location = new System.Drawing.Point(104, 183);
            this._linkLabelCodeGator.Name = "_linkLabelCodeGator";
            this._linkLabelCodeGator.Size = new System.Drawing.Size(133, 17);
            this._linkLabelCodeGator.TabIndex = 17;
            this._linkLabelCodeGator.TabStop = true;
            this._linkLabelCodeGator.Text = "http://codegator.com";
            this._linkLabelCodeGator.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._linkLabelCodeGator_LinkClicked);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(463, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "Traveler Font Copyright (c) 2019 by Mars Traveler. All rights reserved.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _linkLabelScreenSaver
            // 
            this._linkLabelScreenSaver.AutoSize = true;
            this._linkLabelScreenSaver.Location = new System.Drawing.Point(135, 226);
            this._linkLabelScreenSaver.Name = "_linkLabelScreenSaver";
            this._linkLabelScreenSaver.Size = new System.Drawing.Size(381, 17);
            this._linkLabelScreenSaver.TabIndex = 20;
            this._linkLabelScreenSaver.TabStop = true;
            this._linkLabelScreenSaver.Text = "https://sites.harding.edu/fmccown/screensaver/screensaver.html";
            this._linkLabelScreenSaver.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._linkLabelScreenSaver_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = ".NET Screen Saver:";
            // 
            // AboutForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 317);
            this.Controls.Add(this._linkLabelScreenSaver);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._linkLabelCodeGator);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._linkLabelCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._linkLabelFont);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._labelCopyright);
            this.Controls.Add(this._labelTitle);
            this.Controls.Add(this._buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _buttonOk;
        private System.Windows.Forms.Label _labelTitle;
        private System.Windows.Forms.Label _labelCopyright;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel _linkLabelFont;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel _linkLabelCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel _linkLabelCodeGator;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel _linkLabelScreenSaver;
        private System.Windows.Forms.Label label5;
    }
}