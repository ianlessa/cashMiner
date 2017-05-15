namespace Monitor
{
    partial class BootstrapForm
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
            this.Bootstrap_debug_output = new System.Windows.Forms.RichTextBox();
            this.subProgress = new System.Windows.Forms.ProgressBar();
            this.mainProgress = new System.Windows.Forms.ProgressBar();
            this.mainLabel = new System.Windows.Forms.Label();
            this.subLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Bootstrap_debug_output
            // 
            this.Bootstrap_debug_output.Location = new System.Drawing.Point(12, 75);
            this.Bootstrap_debug_output.Name = "Bootstrap_debug_output";
            this.Bootstrap_debug_output.Size = new System.Drawing.Size(723, 460);
            this.Bootstrap_debug_output.TabIndex = 0;
            this.Bootstrap_debug_output.Text = "";
            this.Bootstrap_debug_output.UseWaitCursor = true;
            // 
            // subProgress
            // 
            this.subProgress.Location = new System.Drawing.Point(12, 59);
            this.subProgress.Name = "subProgress";
            this.subProgress.Size = new System.Drawing.Size(310, 10);
            this.subProgress.Step = 1;
            this.subProgress.TabIndex = 1;
            this.subProgress.UseWaitCursor = true;
            // 
            // mainProgress
            // 
            this.mainProgress.Location = new System.Drawing.Point(12, 25);
            this.mainProgress.Name = "mainProgress";
            this.mainProgress.Size = new System.Drawing.Size(311, 10);
            this.mainProgress.TabIndex = 2;
            this.mainProgress.UseWaitCursor = true;
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.Location = new System.Drawing.Point(12, 9);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(74, 13);
            this.mainLabel.TabIndex = 3;
            this.mainLabel.Text = "Inicializando...";
            this.mainLabel.UseWaitCursor = true;
            // 
            // subLabel
            // 
            this.subLabel.AutoSize = true;
            this.subLabel.Location = new System.Drawing.Point(12, 43);
            this.subLabel.Name = "subLabel";
            this.subLabel.Size = new System.Drawing.Size(38, 13);
            this.subLabel.TabIndex = 4;
            this.subLabel.Text = "Tarefa";
            this.subLabel.UseWaitCursor = true;
            // 
            // BootstrapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(747, 547);
            this.ControlBox = false;
            this.Controls.Add(this.subLabel);
            this.Controls.Add(this.mainLabel);
            this.Controls.Add(this.mainProgress);
            this.Controls.Add(this.subProgress);
            this.Controls.Add(this.Bootstrap_debug_output);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BootstrapForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CashMiner Monitor - Inicializando...";
            this.UseWaitCursor = true;
            this.Shown += new System.EventHandler(this.BootstrapForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Bootstrap_debug_output;
        private System.Windows.Forms.ProgressBar subProgress;
        private System.Windows.Forms.ProgressBar mainProgress;
        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.Label subLabel;
    }
}