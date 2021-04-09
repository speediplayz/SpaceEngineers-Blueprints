namespace SE_Blueprints
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtPath = new System.Windows.Forms.TextBox();
            this.cmdStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkLarge = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(75, 13);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(147, 20);
            this.txtPath.TabIndex = 0;
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(12, 88);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(210, 84);
            this.cmdStart.TabIndex = 1;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Save Path";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(75, 39);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(147, 20);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // chkLarge
            // 
            this.chkLarge.AutoSize = true;
            this.chkLarge.Location = new System.Drawing.Point(75, 65);
            this.chkLarge.Name = "chkLarge";
            this.chkLarge.Size = new System.Drawing.Size(77, 17);
            this.chkLarge.TabIndex = 5;
            this.chkLarge.Text = "Large Ship";
            this.chkLarge.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 186);
            this.Controls.Add(this.chkLarge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.txtPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SE Blueprints";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkLarge;
    }
}

