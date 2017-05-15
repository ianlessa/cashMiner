namespace Monitor
{
    partial class RTDLogin
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
            this.RTDUser_label = new System.Windows.Forms.Label();
            this.RTDUser_text = new System.Windows.Forms.TextBox();
            this.RTDConnect_bt = new System.Windows.Forms.Button();
            this.RTDStatus_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RTDUser_label
            // 
            this.RTDUser_label.AutoSize = true;
            this.RTDUser_label.Location = new System.Drawing.Point(9, 10);
            this.RTDUser_label.Name = "RTDUser_label";
            this.RTDUser_label.Size = new System.Drawing.Size(55, 13);
            this.RTDUser_label.TabIndex = 0;
            this.RTDUser_label.Text = "RTD User";
            // 
            // RTDUser_text
            // 
            this.RTDUser_text.ImeMode = System.Windows.Forms.ImeMode.On;
            this.RTDUser_text.Location = new System.Drawing.Point(70, 7);
            this.RTDUser_text.Name = "RTDUser_text";
            this.RTDUser_text.Size = new System.Drawing.Size(118, 20);
            this.RTDUser_text.TabIndex = 1;
            // 
            // RTDConnect_bt
            // 
            this.RTDConnect_bt.Location = new System.Drawing.Point(12, 33);
            this.RTDConnect_bt.Name = "RTDConnect_bt";
            this.RTDConnect_bt.Size = new System.Drawing.Size(176, 23);
            this.RTDConnect_bt.TabIndex = 2;
            this.RTDConnect_bt.Text = "Conectar";
            this.RTDConnect_bt.UseVisualStyleBackColor = true;
            this.RTDConnect_bt.Click += new System.EventHandler(this.RTDConnect_bt_Click);
            // 
            // RTDStatus_label
            // 
            this.RTDStatus_label.AutoSize = true;
            this.RTDStatus_label.Location = new System.Drawing.Point(10, 59);
            this.RTDStatus_label.Name = "RTDStatus_label";
            this.RTDStatus_label.Size = new System.Drawing.Size(80, 13);
            this.RTDStatus_label.TabIndex = 3;
            this.RTDStatus_label.Text = "Desconectado.";
            // 
            // RTDLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 77);
            this.Controls.Add(this.RTDStatus_label);
            this.Controls.Add(this.RTDConnect_bt);
            this.Controls.Add(this.RTDUser_text);
            this.Controls.Add(this.RTDUser_label);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RTDLogin";
            this.ShowIcon = false;
            this.Text = "CashMiner - Monitor";
            //this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RTDLogin_FormClosed);
            this.Load += new System.EventHandler(this.RTDUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RTDUser_label;
        private System.Windows.Forms.TextBox RTDUser_text;
        private System.Windows.Forms.Button RTDConnect_bt;
        private System.Windows.Forms.Label RTDStatus_label;
    }
}

