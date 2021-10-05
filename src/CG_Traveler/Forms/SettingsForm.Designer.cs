namespace CG.Traveler.Forms
{
    partial class SettingsForm
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
            this.components = new System.ComponentModel.Container();
            this._buttonOk = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
            this._buttonAbout = new System.Windows.Forms.Button();
            this._trackBarFontSize = new System.Windows.Forms.TrackBar();
            this._labelFontSize = new System.Windows.Forms.Label();
            this._labelFontFamily = new System.Windows.Forms.Label();
            this._comboBoxFontFamily = new System.Windows.Forms.ComboBox();
            this._labelGlowColor = new System.Windows.Forms.Label();
            this._comboBoxGlowColor = new System.Windows.Forms.ComboBox();
            this._labelSpeed = new System.Windows.Forms.Label();
            this._trackBarSpeed = new System.Windows.Forms.TrackBar();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._trackBarFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._trackBarSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Image = global::CG.Traveler.Properties.Resources.ni0016_24;
            this._buttonOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._buttonOk.Location = new System.Drawing.Point(12, 288);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(91, 38);
            this._buttonOk.TabIndex = 9;
            this._buttonOk.Text = "  Ok";
            this._buttonOk.UseVisualStyleBackColor = true;
            this._buttonOk.Click += new System.EventHandler(this._buttonOk_Click);
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonCancel.Image = global::CG.Traveler.Properties.Resources.ni0067_24;
            this._buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._buttonCancel.Location = new System.Drawing.Point(208, 289);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(84, 37);
            this._buttonCancel.TabIndex = 11;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._buttonCancel.UseVisualStyleBackColor = true;
            this._buttonCancel.Click += new System.EventHandler(this._buttonCancel_Click);
            // 
            // _buttonAbout
            // 
            this._buttonAbout.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonAbout.Image = global::CG.Traveler.Properties.Resources.nd0067_24;
            this._buttonAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._buttonAbout.Location = new System.Drawing.Point(109, 288);
            this._buttonAbout.Name = "_buttonAbout";
            this._buttonAbout.Size = new System.Drawing.Size(93, 38);
            this._buttonAbout.TabIndex = 10;
            this._buttonAbout.Text = "  About";
            this._buttonAbout.UseVisualStyleBackColor = true;
            this._buttonAbout.Click += new System.EventHandler(this._buttonAbout_Click);
            // 
            // _trackBarFontSize
            // 
            this._trackBarFontSize.Location = new System.Drawing.Point(12, 109);
            this._trackBarFontSize.Maximum = 200;
            this._trackBarFontSize.Minimum = 10;
            this._trackBarFontSize.Name = "_trackBarFontSize";
            this._trackBarFontSize.Size = new System.Drawing.Size(280, 45);
            this._trackBarFontSize.TabIndex = 4;
            this._trackBarFontSize.TickFrequency = 10;
            this._toolTip.SetToolTip(this._trackBarFontSize, "How big should the font be?");
            this._trackBarFontSize.Value = 60;
            this._trackBarFontSize.ValueChanged += new System.EventHandler(this._trackBarFontSize_ValueChanged);
            // 
            // _labelFontSize
            // 
            this._labelFontSize.Location = new System.Drawing.Point(12, 85);
            this._labelFontSize.Name = "_labelFontSize";
            this._labelFontSize.Size = new System.Drawing.Size(280, 23);
            this._labelFontSize.TabIndex = 3;
            this._labelFontSize.Text = "Font Size:";
            // 
            // _labelFontFamily
            // 
            this._labelFontFamily.Location = new System.Drawing.Point(12, 157);
            this._labelFontFamily.Name = "_labelFontFamily";
            this._labelFontFamily.Size = new System.Drawing.Size(280, 23);
            this._labelFontFamily.TabIndex = 5;
            this._labelFontFamily.Text = "Font Family:";
            // 
            // _comboBoxFontFamily
            // 
            this._comboBoxFontFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxFontFamily.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._comboBoxFontFamily.FormattingEnabled = true;
            this._comboBoxFontFamily.Location = new System.Drawing.Point(14, 183);
            this._comboBoxFontFamily.Name = "_comboBoxFontFamily";
            this._comboBoxFontFamily.Size = new System.Drawing.Size(278, 25);
            this._comboBoxFontFamily.TabIndex = 6;
            this._toolTip.SetToolTip(this._comboBoxFontFamily, "Which font should we use?");
            // 
            // _labelGlowColor
            // 
            this._labelGlowColor.Location = new System.Drawing.Point(12, 222);
            this._labelGlowColor.Name = "_labelGlowColor";
            this._labelGlowColor.Size = new System.Drawing.Size(280, 23);
            this._labelGlowColor.TabIndex = 7;
            this._labelGlowColor.Text = "Glow Color:";
            // 
            // _comboBoxGlowColor
            // 
            this._comboBoxGlowColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxGlowColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._comboBoxGlowColor.FormattingEnabled = true;
            this._comboBoxGlowColor.Location = new System.Drawing.Point(14, 248);
            this._comboBoxGlowColor.Name = "_comboBoxGlowColor";
            this._comboBoxGlowColor.Size = new System.Drawing.Size(278, 25);
            this._comboBoxGlowColor.TabIndex = 8;
            this._toolTip.SetToolTip(this._comboBoxGlowColor, "What color should we paint with?");
            // 
            // _labelSpeed
            // 
            this._labelSpeed.Location = new System.Drawing.Point(12, 9);
            this._labelSpeed.Name = "_labelSpeed";
            this._labelSpeed.Size = new System.Drawing.Size(280, 23);
            this._labelSpeed.TabIndex = 1;
            this._labelSpeed.Text = "Speed: (milliseconds)";
            // 
            // _trackBarSpeed
            // 
            this._trackBarSpeed.Location = new System.Drawing.Point(12, 33);
            this._trackBarSpeed.Maximum = 5000;
            this._trackBarSpeed.Minimum = 500;
            this._trackBarSpeed.Name = "_trackBarSpeed";
            this._trackBarSpeed.Size = new System.Drawing.Size(280, 45);
            this._trackBarSpeed.TabIndex = 2;
            this._trackBarSpeed.TickFrequency = 150;
            this._toolTip.SetToolTip(this._trackBarSpeed, "How often should we update?");
            this._trackBarSpeed.Value = 1000;
            this._trackBarSpeed.ValueChanged += new System.EventHandler(this._trackBarSpeed_ValueChanged);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(304, 339);
            this.Controls.Add(this._labelSpeed);
            this.Controls.Add(this._trackBarSpeed);
            this.Controls.Add(this._comboBoxGlowColor);
            this.Controls.Add(this._labelGlowColor);
            this.Controls.Add(this._comboBoxFontFamily);
            this.Controls.Add(this._labelFontFamily);
            this.Controls.Add(this._labelFontSize);
            this.Controls.Add(this._trackBarFontSize);
            this.Controls.Add(this._buttonAbout);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this._trackBarFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._trackBarSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _buttonOk;
        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.Button _buttonAbout;
        private System.Windows.Forms.TrackBar _trackBarFontSize;
        private System.Windows.Forms.Label _labelFontSize;
        private System.Windows.Forms.Label _labelFontFamily;
        private System.Windows.Forms.ComboBox _comboBoxFontFamily;
        private System.Windows.Forms.Label _labelGlowColor;
        private System.Windows.Forms.ComboBox _comboBoxGlowColor;
        private System.Windows.Forms.Label _labelSpeed;
        private System.Windows.Forms.TrackBar _trackBarSpeed;
        private System.Windows.Forms.ToolTip _toolTip;
    }
}